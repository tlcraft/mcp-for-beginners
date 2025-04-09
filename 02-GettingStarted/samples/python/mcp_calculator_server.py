#!/usr/bin/env python3
"""
Sample MCP Calculator Server implementation in Python.

This module demonstrates how to create a simple MCP server with a calculator tool
that can perform basic arithmetic operations (add, subtract, multiply, divide).
"""

import json
import logging
from typing import Dict, Any, Optional

from mcp_server import McpServer
from mcp_tools import Tool, ToolRequest, ToolResponse, ToolExecutionException


class CalculatorTool(Tool):
    """
    A tool that performs basic arithmetic operations.
    
    This tool handles add, subtract, multiply, and divide operations
    on two numerical operands.
    """
    
    def get_name(self) -> str:
        """Return the name of the tool."""
        return "calculator"
        
    def get_description(self) -> str:
        """Return a description of the tool."""
        return "Performs basic arithmetic operations"
    
    def get_schema(self) -> Dict[str, Any]:
        """
        Define the schema for the calculator tool.
        
        The schema specifies the required parameters and their types.
        
        Returns:
            Dict[str, Any]: The JSON schema definition
        """
        return {
            "type": "object",
            "properties": {
                "operation": {
                    "type": "string",
                    "enum": ["add", "subtract", "multiply", "divide"],
                    "description": "The arithmetic operation to perform"
                },
                "a": {"type": "number", "description": "First operand"},
                "b": {"type": "number", "description": "Second operand"}
            },
            "required": ["operation", "a", "b"]
        }
      def execute(self, request: ToolRequest) -> ToolResponse:
        """
        Execute the calculation based on the provided operation and operands.
        
        Args:
            request (ToolRequest): The request containing operation parameters
                                  
        Returns:
            ToolResponse: Response containing the calculation result
            
        Raises:
            ToolExecutionException: If division by zero is attempted or an unknown
                                   operation is provided
        """
        # Extract parameters
        params = request.parameters
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
                raise ToolExecutionException("Cannot divide by zero")
            result = a / b
        else:
            raise ToolExecutionException(f"Unknown operation: {operation}")
        
        # Return result
        return ToolResponse(
            result={"result": result}
        )


def configure_logging():
    """Configure basic logging for the application."""
    logging.basicConfig(
        level=logging.INFO,
        format="%(asctime)s - %(name)s - %(levelname)s - %(message)s",
        handlers=[logging.StreamHandler()]
    )


def main():
    """Initialize and start the MCP server with calculator tool."""
    # Configure logging
    configure_logging()
    logger = logging.getLogger(__name__)
    
    # Initialize server
    server = McpServer(
        name="Calculator MCP Server",
        version="1.0.0",
        port=5000
    )
    
    # Register tools
    calculator_tool = CalculatorTool()
    server.register_tool(calculator_tool)
    
    # Start server
    logger.info("Starting Calculator MCP Server on port 5000")
    server.start()


if __name__ == "__main__":
    main()
