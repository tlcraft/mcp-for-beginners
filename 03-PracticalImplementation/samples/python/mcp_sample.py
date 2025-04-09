#!/usr/bin/env python
# MCP Python Sample Implementation

import asyncio
import json
import logging
from typing import Dict, List, Optional, Union

# Mock MCP server implementation
class MCPServer:
    def __init__(self, server_name: str, version: str):
        self.server_name = server_name
        self.version = version
        self.models = ["gpt-4", "llama-3-70b", "claude-3-sonnet"]
        self.logger = logging.getLogger("mcp.server")
        self.logger.setLevel(logging.INFO)
        handler = logging.StreamHandler()
        formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
        handler.setFormatter(formatter)
        self.logger.addHandler(handler)
    
    async def handle_completion_request(self, request: Dict) -> Dict:
        """Handle an MCP completion request"""
        self.logger.info(f"Processing completion request for model: {request.get('model', 'unknown')}")
        
        # Validate request
        if 'model' not in request:
            return {"error": "Model is required"}
        
        if request['model'] not in self.models:
            return {"error": f"Model {request['model']} not supported"}
            
        if 'prompt' not in request:
            return {"error": "Prompt is required"}
            
        # In a real implementation, this would call an AI model
        # Here we just echo back parts of the request with a mock response
        response = {
            "id": "mcp-resp-" + request.get('id', '12345'),
            "model": request['model'],
            "response": f"This is a response to: {request['prompt'][:30]}...",
            "usage": {
                "prompt_tokens": len(request['prompt'].split()),
                "completion_tokens": 20,
                "total_tokens": len(request['prompt'].split()) + 20
            }
        }
        
        # Simulate network delay
        await asyncio.sleep(0.5)
        return response

# MCP Client implementation
class MCPClient:
    def __init__(self, server_url: str):
        self.server_url = server_url
        self.logger = logging.getLogger("mcp.client")
        self.logger.setLevel(logging.INFO)
        
    async def create_completion(self, 
                               model: str, 
                               prompt: str, 
                               temperature: float = 0.7, 
                               max_tokens: int = 100) -> Dict:
        """Send a completion request to an MCP server"""
        self.logger.info(f"Sending completion request to {self.server_url}")
        
        # In a real implementation, this would use HTTP to send the request
        # Here we simulate by directly creating and returning a request object
        request = {
            "id": "req-123456",
            "model": model,
            "prompt": prompt,
            "temperature": temperature,
            "max_tokens": max_tokens
        }
        
        # This would normally be sent over HTTP
        # For this sample, we'll create a server and call it directly
        server = MCPServer("Sample MCP Server", "1.0")
        return await server.handle_completion_request(request)

async def main():
    # Example usage
    client = MCPClient("https://mcp.example.org")
    response = await client.create_completion(
        model="gpt-4",
        prompt="Explain the Model Context Protocol in simple terms",
        temperature=0.7,
        max_tokens=100
    )
    
    print("\n--- MCP Response ---")
    print(json.dumps(response, indent=2))

if __name__ == "__main__":
    asyncio.run(main())
