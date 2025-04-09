#!/usr/bin/env python3
"""
Sample MCP Calculator Server implementation in Python.

This module demonstrates how to create a simple MCP server with a calculator tool
that can perform basic arithmetic operations (add, subtract, multiply, divide).
"""

import asyncio
import logging
from typing import Dict, Any, List, Literal

from modelcontextprotocol import create_server
from modelcontextprotocol.server import MCPServer, ServerConfig
from modelcontextprotocol.tool import ToolDefinition, ToolParameters, ToolResponse
from modelcontextprotocol.transports import create_stdio_transport
from modelcontextprotocol.exceptions import MCPToolError


async def calculator_tool(params: ToolParameters) -> ToolResponse:
    """
    A tool that performs basic arithmetic operations.
    
    This tool handles add, subtract, multiply, and divide operations
    on two numerical operands.
    """
    operation = params["operation"]
    a = params["a"]
    b = params["b"]
    
    result = None
    try:
        if operation == "add":
            result = a + b
        elif operation == "subtract":
            result = a - b
        elif operation == "multiply":
            result = a * b
        elif operation == "divide":
            if b == 0:
                raise MCPToolError("Cannot divide by zero")
            result = a / b
        else:
            raise MCPToolError(f"Unknown operation: {operation}")
    except Exception as e:
        raise MCPToolError(f"Error performing calculation: {str(e)}")
    
    return ToolResponse(content={"result": result})
        """
        Execute the calculation based on the provided operation and operands.
        
        Args:
            params: Dictionary containing the operation parameters
                                  
        Returns:
            Dictionary containing the calculation result
            
        Raises:
            ToolExecutionError: If division by zero is attempted or an unknown
                                operation is provided
        """
        # Extract parameters
        operation = params.get("operation")
        a = params.get("a")
        b = params.get("b")
        
        # Perform calculation
        if operation == "add":
            result = a + b
        elif operation == "subtract":
            result = a - b
        elif operation == "multiply":
            result = a * b
        elif operation == "divide":
            if b == 0:
                raise ToolExecutionError("Cannot divide by zero")
            result = a / b
        else:
            raise ToolExecutionError(f"Unknown operation: {operation}")
        
        # Return result in the content format
        return {
            "content": [
                {
                    "type": "text",
                    "text": f'{{"result": {result}}}'
                }
            ]
        }


def configure_logging():
    """Configure basic logging for the application."""
    logging.basicConfig(
        level=logging.INFO,
        format="%(asctime)s - %(name)s - %(levelname)s - %(message)s",
        handlers=[logging.StreamHandler()]
    )


async def main():
    """Initialize and start the MCP server with calculator tool."""
    # Configure logging
    configure_logging()
    logger = logging.getLogger(__name__)
    
    logger.info("Creating Calculator MCP Server")
    
    # Define the calculator tool
    calculator_definition = ToolDefinition(
        name="calculator",
        description="Performs basic arithmetic operations",
        parameters={
            "operation": {
                "type": "string",
                "enum": ["add", "subtract", "multiply", "divide"],
                "description": "The arithmetic operation to perform"
            },
            "a": {
                "type": "number",
                "description": "First operand"
            },
            "b": {
                "type": "number",
                "description": "Second operand"
            }
        },
        required=["operation", "a", "b"]
    )
    
    # Create server configuration
    config = ServerConfig(
        name="Calculator MCP Server",
        version="1.0.0"
    )
    
    # Create server
    server = create_server(config)
    
    # Register the calculator tool
    server.tools.register(calculator_definition, calculator_tool)
    
    # Connect the server using stdio transport
    logger.info("Starting Calculator MCP Server with stdio transport")
    transport = create_stdio_transport()
    await server.run(transport)


if __name__ == "__main__":
    asyncio.run(main())
