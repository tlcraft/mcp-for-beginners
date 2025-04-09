// mcp_calculator_server.ts - Sample MCP Calculator Server implementation in TypeScript
import { createServer } from '@modelcontextprotocol/typescript-sdk/server';
import { createStdioTransport } from '@modelcontextprotocol/typescript-sdk/transports';
import { z } from 'zod';

// Create an MCP server
const server = createServer({
  name: 'Calculator MCP Server',
  version: '1.0.0'
});

// Define the calculator tool
server.tools.register({
  name: 'calculator',
  description: 'Performs basic arithmetic calculations',
  parameters: z.object({
    operation: z.enum(['add', 'subtract', 'multiply', 'divide']),
    a: z.number(),
    b: z.number()
  }),
  execute: async ({ operation, a, b }) => {
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
      content: [
        {
          type: 'text',
          text: JSON.stringify({ result })
        }
      ]
    };
  }
);

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log('Calculator MCP Server started');
