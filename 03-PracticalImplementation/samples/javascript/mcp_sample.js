// MCP JavaScript/Node.js Sample Implementation

const EventEmitter = require('events');

/**
 * MCP Server implementation in JavaScript
 */
class MCPServer {
  constructor(options = {}) {
    this.serverName = options.serverName || 'JavaScript MCP Server';
    this.version = options.version || '1.0.0';
    this.models = options.models || ['gpt-4', 'llama-3-70b', 'claude-3-sonnet'];
    this.events = new EventEmitter();
  }

  /**
   * Handle an MCP completion request
   * @param {Object} request - The MCP request object
   * @returns {Promise<Object>} - The MCP response
   */
  async handleCompletionRequest(request) {
    console.log(`Processing completion request for model: ${request.model || 'unknown'}`);
    
    // Validate request
    if (!request.model) {
      return { error: 'Model is required' };
    }
    
    if (!this.models.includes(request.model)) {
      return { error: `Model ${request.model} not supported` };
    }
    
    if (!request.prompt) {
      return { error: 'Prompt is required' };
    }
    
    // Emit event for monitoring/metrics
    this.events.emit('request', { 
      type: 'completion', 
      model: request.model, 
      timestamp: new Date() 
    });
    
    // In a real implementation, this would call an AI model
    // Here we just echo back parts of the request with a mock response
    const response = {
      id: `mcp-resp-${request.id || Date.now()}`,
      model: request.model,
      response: `This is a response to: ${request.prompt.substring(0, 30)}...`,
      usage: {
        promptTokens: request.prompt.split(' ').length,
        completionTokens: 20,
        totalTokens: request.prompt.split(' ').length + 20
      }
    };
    
    // Simulate network delay
    await new Promise(resolve => setTimeout(resolve, 500));
    
    // Emit completion event
    this.events.emit('completion', {
      requestId: request.id,
      model: request.model,
      timestamp: new Date()
    });
    
    return response;
  }
  
  /**
   * Stream a completion response
   * @param {Object} request - The MCP request object
   * @returns {AsyncGenerator<Object>} - The streaming response
   */
  async *streamCompletion(request) {
    // Validate request
    if (!request.model || !request.prompt) {
      yield { error: 'Invalid request parameters' };
      return;
    }
    
    // Mock streaming response generation
    const words = `This is a streaming response to your prompt about ${
      request.prompt.split(' ').slice(0, 3).join(' ')
    }... The response will come word by word as a demonstration of streaming capabilities.`.split(' ');
    
    for (const word of words) {
      // Simulate token-by-token generation
      await new Promise(resolve => setTimeout(resolve, 100));
      yield {
        id: `mcp-stream-${request.id || Date.now()}`,
        model: request.model,
        delta: word + ' ',
        finished: false
      };
    }
    
    // Final message
    yield {
      id: `mcp-stream-${request.id || Date.now()}`,
      model: request.model,
      delta: '',
      finished: true,
      usage: {
        promptTokens: request.prompt.split(' ').length,
        completionTokens: words.length,
        totalTokens: request.prompt.split(' ').length + words.length
      }
    };
  }
}

/**
 * MCP Client implementation in JavaScript
 */
class MCPClient {
  constructor(serverUrl) {
    this.serverUrl = serverUrl;
  }
  
  /**
   * Send a completion request to an MCP server
   * @param {Object} options - The request options
   * @returns {Promise<Object>} - The completion response
   */
  async createCompletion(options) {
    console.log(`Sending completion request to ${this.serverUrl}`);
    
    if (!options.model || !options.prompt) {
      throw new Error('Model and prompt are required');
    }
    
    const request = {
      id: `req-${Date.now()}`,
      model: options.model,
      prompt: options.prompt,
      temperature: options.temperature ?? 0.7,
      maxTokens: options.maxTokens ?? 100
    };
    
    // In a real implementation, this would use fetch or axios to send an HTTP request
    // For this sample, we'll create a server and call it directly
    const server = new MCPServer();
    return await server.handleCompletionRequest(request);
  }
  
  /**
   * Stream a completion from an MCP server
   * @param {Object} options - The request options
   * @returns {AsyncGenerator<Object>} - The streaming response
   */
  async *createCompletionStream(options) {
    console.log(`Starting streaming completion with ${this.serverUrl}`);
    
    if (!options.model || !options.prompt) {
      throw new Error('Model and prompt are required');
    }
    
    const request = {
      id: `req-stream-${Date.now()}`,
      model: options.model,
      prompt: options.prompt,
      temperature: options.temperature ?? 0.7,
      maxTokens: options.maxTokens ?? 100,
      stream: true
    };
    
    // In a real implementation, this would use fetch with streaming or a WebSocket
    // For this sample, we'll create a server and yield from its generator
    const server = new MCPServer();
    yield* server.streamCompletion(request);
  }
}

// Example usage
async function runExample() {
  const client = new MCPClient('https://mcp.example.org');
  
  // Standard completion example
  console.log('\n--- Standard Completion Example ---');
  const response = await client.createCompletion({
    model: 'gpt-4',
    prompt: 'Explain the Model Context Protocol in simple terms',
    temperature: 0.7,
    maxTokens: 100
  });
  
  console.log(JSON.stringify(response, null, 2));
  
  // Streaming example
  console.log('\n--- Streaming Example ---');
  const streamingClient = new MCPClient('https://mcp.example.org');
  
  let fullResponse = '';
  for await (const chunk of streamingClient.createCompletionStream({
    model: 'gpt-4',
    prompt: 'Explain streaming in MCP',
    temperature: 0.7
  })) {
    if (chunk.delta) {
      process.stdout.write(chunk.delta);
      fullResponse += chunk.delta;
    }
    if (chunk.finished) {
      console.log('\n\nStream finished');
      console.log('Usage:', chunk.usage);
    }
  }
}

// Run the example if this file is executed directly
if (require.main === module) {
  runExample().catch(console.error);
}

module.exports = { MCPServer, MCPClient };
