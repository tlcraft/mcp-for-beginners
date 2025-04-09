// mcp_calculator_server.js - Sample MCP Calculator Server implementation in JavaScript
const express = require('express');
const { McpServer, ToolRegistry } = require('@mcp/server');

class CalculatorTool {
  getName() {
    return 'calculator';
  }

  getDescription() {
    return 'Performs basic arithmetic operations';
  }

  getSchema() {
    return {
      type: 'object',
      properties: {
        operation: {
          type: 'string',
          enum: ['add', 'subtract', 'multiply', 'divide'],
          description: 'The arithmetic operation to perform'
        },
        a: {
          type: 'number',
          description: 'First operand'
        },
        b: {
          type: 'number',
          description: 'Second operand'
        }
      },
      required: ['operation', 'a', 'b']
    };
  }

  async execute(request) {
    const { operation, a, b } = request.parameters;
    let result = 0;

    // Perform calculation
    switch (operation) {
      case 'add':
        result = a + b;
        break;
      case 'subtract':
        result = a - b;
        break;
      case 'multiply':
        result = a * b;
        break;
      case 'divide':
        if (b === 0) {
          throw new Error('Cannot divide by zero');
        }
        result = a / b;
        break;
      default:
        throw new Error(`Unknown operation: ${operation}`);
    }

    // Return result
    return {
      result: result
    };
  }
}

// Create Express app
const app = express();
app.use(express.json());

// Create and configure MCP server
const toolRegistry = new ToolRegistry();
toolRegistry.registerTool(new CalculatorTool());

const mcpServer = new McpServer({
  serverName: 'Calculator MCP Server',
  serverVersion: '1.0.0',
  toolRegistry: toolRegistry
});

// Set up MCP endpoints
app.post('/mcp/execute', async (req, res) => {
  try {
    const response = await mcpServer.handleRequest(req.body);
    res.json(response);
  } catch (error) {
    res.status(400).json({ error: error.message });
  }
});

app.get('/mcp/tools', (req, res) => {
  res.json(mcpServer.getAvailableTools());
});

// Start server
const PORT = process.env.PORT || 5000;
app.listen(PORT, () => {
  console.log(`Calculator MCP Server started on port ${PORT}`);
});
