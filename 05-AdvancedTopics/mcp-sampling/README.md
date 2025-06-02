## Sampling in Model Context Protocol

Sampling strategies are critical for optimizing model responses in MCP implementations. The right sampling configuration can dramatically improve response quality and performance. MCP provides a standardized way to control how models generate text with specific parameters that influence randomness, creativity, and coherence.

### Sampling Parameters Overview

MCP defines the following sampling parameters that can be configured in client requests:

| Parameter | Description | Typical Range |
|-----------|-------------|---------------|
| `temperature` | Controls randomness in token selection | 0.0 - 2.0 |
| `top_p` | Nucleus sampling - limits tokens to top cumulative probability | 0.0 - 1.0 |
| `top_k` | Limits token selection to top K options | 1 - 100 |
| `presence_penalty` | Penalizes tokens based on their presence in the text so far | -2.0 - 2.0 |
| `frequency_penalty` | Penalizes tokens based on their frequency in the text so far | -2.0 - 2.0 |
| `seed` | Specific random seed for reproducible results | Integer value |
| `max_tokens` | Maximum number of tokens to generate | Integer value |
| `stop_sequences` | Custom sequences that stop generation when encountered | Array of strings |

### Temperature and Top-K/Top-P Sampling

Sampling parameters allow fine-tuning the behavior of language models to achieve the desired balance between deterministic and creative outputs.

```csharp
// .NET Example: Configuring sampling parameters in MCP
public class SamplingExample
{
    public async Task RunWithSamplingAsync()
    {
        // Create MCP client with sampling configuration
        var client = new McpClient("https://mcp-server-url.com");
        
        // Create request with specific sampling parameters
        var request = new McpRequest
        {
            Prompt = "Generate creative ideas for a mobile app",
            SamplingParameters = new SamplingParameters
            {
                Temperature = 0.8f,     // Higher temperature for more creative outputs
                TopP = 0.95f,           // Nucleus sampling parameter
                TopK = 40,              // Limit token selection to top K options
                FrequencyPenalty = 0.5f, // Reduce repetition
                PresencePenalty = 0.2f   // Encourage diversity
            },
            AllowedTools = new[] { "ideaGenerator", "marketAnalyzer" }
        };
        
        // Send request using specific sampling configuration
        var response = await client.SendRequestAsync(request);
        
        // Output results
        Console.WriteLine($"Generated with Temperature={request.SamplingParameters.Temperature}:");
        Console.WriteLine(response.GeneratedText);
    }
}
```

```javascript
// JavaScript Example: Temperature and Top-P sampling configuration
const { McpClient } = require('@mcp/client');

async function demonstrateSampling() {
  // Initialize the MCP client
  const client = new McpClient({
    serverUrl: 'https://mcp-server-example.com',
    apiKey: process.env.MCP_API_KEY
  });
  
  // Configure request with different sampling parameters
  const creativeSampling = {
    temperature: 0.9,    // Higher temperature = more randomness/creativity
    topP: 0.92,          // Consider tokens with top 92% probability mass
    frequencyPenalty: 0.6, // Reduce repetition of token sequences
    presencePenalty: 0.4   // Penalize tokens that have appeared in the text so far
  };
  
  const factualSampling = {
    temperature: 0.2,    // Lower temperature = more deterministic/factual
    topP: 0.85,          // Slightly more focused token selection
    frequencyPenalty: 0.2, // Minimal repetition penalty
    presencePenalty: 0.1   // Minimal presence penalty
  };
  
  try {
    // Send two requests with different sampling configurations
    const creativeResponse = await client.sendPrompt(
      "Generate innovative ideas for sustainable urban transportation",
      {
        allowedTools: ['ideaGenerator', 'environmentalImpactTool'],
        ...creativeSampling
      }
    );
    
    const factualResponse = await client.sendPrompt(
      "Explain how electric vehicles impact carbon emissions",
      {
        allowedTools: ['factChecker', 'dataAnalysisTool'],
        ...factualSampling
      }
    );
    
    console.log('Creative Response (temperature=0.9):');
    console.log(creativeResponse.generatedText);
    
    console.log('\nFactual Response (temperature=0.2):');
    console.log(factualResponse.generatedText);
    
  } catch (error) {
    console.error('Error demonstrating sampling:', error);
  }
}

demonstrateSampling();
```

### Deterministic Sampling

For applications requiring consistent outputs, deterministic sampling ensures reproducible results.

```java
// Java Example: Deterministic responses with fixed seed
public class DeterministicSamplingExample {
    public void demonstrateDeterministicResponses() {
        McpClient client = new McpClient.Builder()
            .setServerUrl("https://mcp-server-example.com")
            .build();
            
        long fixedSeed = 12345; // Using a fixed seed for deterministic results
        
        // First request with fixed seed
        McpRequest request1 = new McpRequest.Builder()
            .setPrompt("Generate a random number between 1 and 100")
            .setSeed(fixedSeed)
            .setTemperature(0.0) // Zero temperature for maximum determinism
            .build();
            
        // Second request with the same seed
        McpRequest request2 = new McpRequest.Builder()
            .setPrompt("Generate a random number between 1 and 100")
            .setSeed(fixedSeed)
            .setTemperature(0.0)
            .build();
        
        // Execute both requests
        McpResponse response1 = client.sendRequest(request1);
        McpResponse response2 = client.sendRequest(request2);
        
        // Responses should be identical due to same seed and temperature=0
        System.out.println("Response 1: " + response1.getGeneratedText());
        System.out.println("Response 2: " + response2.getGeneratedText());
        System.out.println("Are responses identical: " + 
            response1.getGeneratedText().equals(response2.getGeneratedText()));
    }
}
```

```javascript
// JavaScript Example: Deterministic responses with seed control
const { McpClient } = require('@mcp/client');

async function deterministicSampling() {
  const client = new McpClient({
    serverUrl: 'https://mcp-server-example.com'
  });
  
  const fixedSeed = 12345;
  const prompt = "Generate a random password with 8 characters";
  
  try {
    // First request with fixed seed
    const response1 = await client.sendPrompt(prompt, {
      seed: fixedSeed,
      temperature: 0.0  // Zero temperature for maximum determinism
    });
    
    // Second request with same seed and temperature
    const response2 = await client.sendPrompt(prompt, {
      seed: fixedSeed,
      temperature: 0.0
    });
    
    // Third request with different seed but same temperature
    const response3 = await client.sendPrompt(prompt, {
      seed: 67890,
      temperature: 0.0
    });
    
    console.log('Response 1:', response1.generatedText);
    console.log('Response 2:', response2.generatedText);
    console.log('Response 3:', response3.generatedText);
    console.log('Responses 1 and 2 match:', response1.generatedText === response2.generatedText);
    console.log('Responses 1 and 3 match:', response1.generatedText === response3.generatedText);
    
  } catch (error) {
    console.error('Error in deterministic sampling demo:', error);
  }
}

deterministicSampling();
```

### Dynamic Sampling Configuration

Intelligent sampling adapts parameters based on the context and requirements of each request.

```python
# Python Example: Dynamic sampling based on request context
class DynamicSamplingService:
    def __init__(self, mcp_client):
        self.client = mcp_client
        
    async def generate_with_adaptive_sampling(self, prompt, task_type, user_preferences=None):
        """Uses different sampling strategies based on task type and user preferences"""
        
        # Define sampling presets for different task types
        sampling_presets = {
            "creative": {"temperature": 0.9, "top_p": 0.95, "frequency_penalty": 0.7},
            "factual": {"temperature": 0.2, "top_p": 0.85, "frequency_penalty": 0.2},
            "code": {"temperature": 0.3, "top_p": 0.9, "frequency_penalty": 0.5},
            "analytical": {"temperature": 0.4, "top_p": 0.92, "frequency_penalty": 0.3}
        }
        
        # Select base preset
        sampling_params = sampling_presets.get(task_type, sampling_presets["factual"])
        
        # Adjust based on user preferences if provided
        if user_preferences:
            if "creativity_level" in user_preferences:
                # Scale temperature based on creativity preference (1-10)
                creativity = min(max(user_preferences["creativity_level"], 1), 10) / 10
                sampling_params["temperature"] = 0.1 + (0.9 * creativity)
            
            if "diversity" in user_preferences:
                # Adjust top_p based on desired response diversity
                diversity = min(max(user_preferences["diversity"], 1), 10) / 10
                sampling_params["top_p"] = 0.6 + (0.39 * diversity)
        
        # Create and send request with custom sampling parameters
        response = await self.client.send_request(
            prompt=prompt,
            temperature=sampling_params["temperature"],
            top_p=sampling_params["top_p"],
            frequency_penalty=sampling_params["frequency_penalty"]
        )
        
        # Return response with sampling metadata for transparency
        return {
            "text": response.generated_text,
            "applied_sampling": sampling_params,
            "task_type": task_type
        }
```

```javascript
// JavaScript Example: Dynamic sampling configuration based on user context
class AdaptiveSamplingManager {
  constructor(mcpClient) {
    this.client = mcpClient;
    
    // Define base sampling profiles
    this.samplingProfiles = {
      creative: { temperature: 0.85, topP: 0.94, frequencyPenalty: 0.7, presencePenalty: 0.5 },
      factual: { temperature: 0.2, topP: 0.85, frequencyPenalty: 0.3, presencePenalty: 0.1 },
      code: { temperature: 0.25, topP: 0.9, frequencyPenalty: 0.4, presencePenalty: 0.3 },
      conversational: { temperature: 0.7, topP: 0.9, frequencyPenalty: 0.6, presencePenalty: 0.4 }
    };
    
    // Track historical performance
    this.performanceHistory = [];
  }
  
  // Detect task type from prompt
  detectTaskType(prompt, context = {}) {
    const promptLower = prompt.toLowerCase();
    
    // Simple heuristic detection - could be enhanced with ML classification
    if (context.taskType) return context.taskType;
    
    if (promptLower.includes('code') || 
        promptLower.includes('function') || 
        promptLower.includes('program')) {
      return 'code';
    }
    
    if (promptLower.includes('explain') || 
        promptLower.includes('what is') || 
        promptLower.includes('how does')) {
      return 'factual';
    }
    
    if (promptLower.includes('creative') || 
        promptLower.includes('imagine') || 
        promptLower.includes('story')) {
      return 'creative';
    }
    
    // Default to conversational if no clear type is detected
    return 'conversational';
  }
  
  // Calculate sampling parameters based on context and user preferences
  getSamplingParameters(prompt, context = {}) {
    // Detect the type of task
    const taskType = this.detectTaskType(prompt, context);
    
    // Get base profile
    let params = {...this.samplingProfiles[taskType]};
    
    // Adjust based on user preferences
    if (context.userPreferences) {
      const { creativity, precision, consistency } = context.userPreferences;
      
      if (creativity !== undefined) {
        // Scale from 1-10 to appropriate temperature range
        params.temperature = 0.1 + (creativity * 0.09); // 0.1-1.0
      }
      
      if (precision !== undefined) {
        // Higher precision means lower topP (more focused selection)
        params.topP = 1.0 - (precision * 0.05); // 0.5-1.0
      }
      
      if (consistency !== undefined) {
        // Higher consistency means lower penalties
        params.frequencyPenalty = 0.1 + ((10 - consistency) * 0.08); // 0.1-0.9
      }
    }
    
    // Apply learned adjustments from performance history
    this.applyLearnedAdjustments(params, taskType);
    
    return params;
  }
  
  applyLearnedAdjustments(params, taskType) {
    // Simple adaptive logic - could be enhanced with more sophisticated algorithms
    const relevantHistory = this.performanceHistory
      .filter(entry => entry.taskType === taskType)
      .slice(-5); // Only consider recent history
    
    if (relevantHistory.length > 0) {
      // Calculate average performance scores
      const avgScore = relevantHistory.reduce((sum, entry) => sum + entry.score, 0) / relevantHistory.length;
      
      // If performance is below threshold, adjust parameters
      if (avgScore < 0.7) {
        // Slight adjustment toward safer values
        params.temperature = Math.max(params.temperature * 0.9, 0.1);
        params.topP = Math.max(params.topP * 0.95, 0.5);
      }
    }
  }
  
  recordPerformance(prompt, samplingParams, response, score) {
    // Record performance for future adjustments
    this.performanceHistory.push({
      timestamp: Date.now(),
      taskType: this.detectTaskType(prompt),
      samplingParams,
      responseLength: response.generatedText.length,
      score // 0-1 rating of response quality
    });
    
    // Limit history size
    if (this.performanceHistory.length > 100) {
      this.performanceHistory.shift();
    }
  }
  
  async generateResponse(prompt, context = {}) {
    // Get optimized sampling parameters
    const samplingParams = this.getSamplingParameters(prompt, context);
    
    // Send request with optimized parameters
    const response = await this.client.sendPrompt(prompt, {
      ...samplingParams,
      allowedTools: context.allowedTools || []
    });
    
    // If user provides feedback, record it for future optimization
    if (context.recordPerformance) {
      this.recordPerformance(prompt, samplingParams, response, context.feedbackScore || 0.5);
    }
    
    return {
      response,
      appliedSamplingParams: samplingParams,
      detectedTaskType: this.detectTaskType(prompt, context)
    };
  }
}

// Example usage
async function demonstrateAdaptiveSampling() {
  const client = new McpClient({
    serverUrl: 'https://mcp-server-example.com'
  });
  
  const samplingManager = new AdaptiveSamplingManager(client);
  
  try {
    // Creative task with custom user preferences
    const creativeResult = await samplingManager.generateResponse(
      "Write a short poem about artificial intelligence",
      {
        userPreferences: {
          creativity: 9,  // High creativity (1-10)
          consistency: 3  // Low consistency (1-10)
        }
      }
    );
    
    console.log('Creative Task:');
    console.log(`Detected type: ${creativeResult.detectedTaskType}`);
    console.log('Applied sampling:', creativeResult.appliedSamplingParams);
    console.log(creativeResult.response.generatedText);
    
    // Code generation task
    const codeResult = await samplingManager.generateResponse(
      "Write a JavaScript function to calculate the Fibonacci sequence",
      {
        userPreferences: {
          creativity: 2,  // Low creativity
          precision: 8,   // High precision
          consistency: 9  // High consistency
        }
      }
    );
    
    console.log('\nCode Task:');
    console.log(`Detected type: ${codeResult.detectedTaskType}`);
    console.log('Applied sampling:', codeResult.appliedSamplingParams);
    console.log(codeResult.response.generatedText);
    
  } catch (error) {
    console.error('Error in adaptive sampling demo:', error);
  }
}

demonstrateAdaptiveSampling();
```
