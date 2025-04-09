#!/usr/bin/env python3
"""
Model Context Protocol (MCP) Python Sample Implementation.

This module demonstrates how to implement a basic MCP server that can handle
completion requests. It provides a mock implementation that simulates
interaction with various AI models.

For more information about MCP: https://modelcontextprotocol.io/
"""

import asyncio
import json
import logging
from typing import Dict, List, Any, Optional

from modelcontextprotocol import create_server
from modelcontextprotocol.server import MCPServer, ServerConfig
from modelcontextprotocol.tool import ToolDefinition, ToolParameters, ToolResponse
from modelcontextprotocol.resource import ResourceDefinition, ResourceParameters, ResourceResponse
from modelcontextprotocol.content import ContentItem, TextContent
from modelcontextprotocol.transports import create_stdio_transport
from modelcontextprotocol.exceptions import MCPToolError, MCPResourceError

# Configure module logger
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)


class ExtendedMcpServer:
    """Extended MCP Server implementation with additional features."""
    
    def __init__(self, name="Python MCP Server", version="1.0.0"):
        """Initialize the MCP server instance."""
        self.name = name
        self.version = version
        self.models = ["gpt-4", "llama-3-70b", "claude-3-sonnet"]
        
        # Create the server configuration
        config = ServerConfig(
            name=self.name,
            version=self.version,
            description="An extended MCP server implementation with multiple features"
        )
        
        # Create the core MCP server
        self.server = create_server(config)
        
        # Register completion tool
        self._register_completion_tool()
        
        # Register models resource
        self._register_models_resource()
      def _register_completion_tool(self):
        """Register the completion tool with the server."""
        # Define the tool with parameters
        completion_tool = ToolDefinition(
            name="completion",
            description="Generate completions using AI models",
            parameters={
                "model": {
                    "type": "string",
                    "enum": self.models,
                    "description": "The AI model to use for completion"
                },
                "prompt": {
                    "type": "string",
                    "description": "The prompt text to complete"
                },
                "temperature": {
                    "type": "number",
                    "description": "Sampling temperature (0.0 to 1.0)"
                },
                "max_tokens": {
                    "type": "number",
                    "description": "Maximum number of tokens to generate"
                }
            },
            required=["model", "prompt"]
        )
        
        # Register the tool with its handler
        self.server.tools.register(completion_tool, self._handle_completion)
      async def _handle_completion(self, params: ToolParameters) -> ToolResponse:
        """Handle completion requests."""
        model = params["model"]
        prompt = params["prompt"]
        logger.info(f"Processing completion request for model: {model}")
        
        # Validate model
        if model not in self.models:
            raise MCPToolError(f"Model {model} not supported")
        
        # In a real implementation, this would call an AI model
        # Here we just echo back parts of the request with a mock response
        completion_text = f"This is a response to: {prompt[:30]}..."
        
        # Return structured response
        return ToolResponse(
            content=[
                TextContent(completion_text)
            ],
            metadata={
                "id": f"mcp-resp-{asyncio.get_event_loop().time()}",
                "model": model,
            }
            "usage": {
                "promptTokens": len(prompt.split()),
                "completionTokens": 20,
                "totalTokens": len(prompt.split()) + 20
            }
        }
        
        # Simulate network delay
        await asyncio.sleep(0.5)
        
        # Return result in the content format
        return {
            "content": [
                {
                    "type": "text",
                    "text": json.dumps(response)
                }
            ]
        }
    
    def _create_models_resource(self) -> Resource:
        """Create and return the models resource."""
        class ModelsResource(Resource):
            async def get(self, uri, params=None):
                logger.info("Retrieving available models")
                models_data = [
                    {
                        "id": "gpt-4",
                        "name": "GPT-4",
                        "description": "OpenAI's GPT-4 large language model"
                    },
                    {
                        "id": "llama-3-70b",
                        "name": "LLaMA 3 (70B)",
                        "description": "Meta's LLaMA 3 with 70 billion parameters"
                    },
                    {
                        "id": "claude-3-sonnet",
                        "name": "Claude 3 Sonnet",
                        "description": "Anthropic's Claude 3 Sonnet model"
                    }
                ]
                
                return {
                    "contents": [
                        {
                            "uri": uri.href,
                            "text": json.dumps({"models": models_data})
                        }
                    ]
                }
        
        return ModelsResource('models://', template='models://')
    
    async def connect(self):
        """Connect the server using stdio transport."""
        transport = StdioTransport()
        await self.server.connect(transport)
        logger.info(f"Server connected via stdio transport")
    
    def get_supported_models(self):
        """Return the list of supported models."""
        return list(self.models)


async def main():
    """Initialize and start the MCP server."""
    # Create the extended MCP server
    server = ExtendedMcpServer(
        name="Python MCP Demo Server",
        version="1.0.0"
    )
    
    logger.info(f"MCP Server '{server.name}' initialized")
    logger.info(f"Supported models: {', '.join(server.get_supported_models())}")
    
    # Connect and run the server
    await server.connect()


if __name__ == "__main__":
    asyncio.run(main())
