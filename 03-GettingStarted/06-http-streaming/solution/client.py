# client.py
from mcp.client.streamable_http import streamablehttp_client
from mcp import ClientSession
import asyncio
import mcp.types as types
from mcp.shared.session import RequestResponder
import requests

class LoggingCollector:
    def __init__(self):
        self.log_messages: list[types.LoggingMessageNotificationParams] = []
    async def __call__(self, params: types.LoggingMessageNotificationParams) -> None:
        self.log_messages.append(params)

logging_collector = LoggingCollector()
port = 8000

async def message_handler(
    message: RequestResponder[types.ServerRequest, types.ClientResult]
    | types.ServerNotification
    | Exception,
) -> None:
    print("Received message:", message)
    if isinstance(message, Exception):
        print("Exception received!")
        raise message
    elif isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    elif isinstance(message, RequestResponder):
        print("REQUEST_RESPONDER:", message)
    else:
        print("SERVER_MESSAGE:", message)

async def main():
    print("Starting client...")
    async with streamablehttp_client(f"http://localhost:{port}/mcp") as (
        read_stream,
        write_stream,
        session_callback,
    ):
        async with ClientSession(
            read_stream,
            write_stream,
            logging_callback=logging_collector,
            message_handler=message_handler,
        ) as session:
            id_before = session_callback()
            print("Session ID before init:", id_before)
            await session.initialize()
            id_after = session_callback()
            print("Session ID after init:", id_after)
            print("Session initialized, ready to call tools.")
            tool_result = await session.call_tool("process_files", {"message": "hello from client"})
            print("Tool result:", tool_result)
            if logging_collector.log_messages:
                print("Collected log messages:")
                for log in logging_collector.log_messages:
                    print(log)

def stream_progress(message="hello", url="http://localhost:8000/stream"):
    params = {"message": message}
    print(f"Connecting to {url} with message: {message}\n")
    try:
        with requests.get(url, params=params, stream=True, timeout=10) as r:
            r.raise_for_status()
            print("--- Streaming Progress ---")
            for line in r.iter_lines():
                if line:
                    print(line.decode().strip())
            print("--- Stream Ended ---")
    except requests.RequestException as e:
        print(f"Error: {e}")

if __name__ == "__main__":
    import sys
    
    if len(sys.argv) > 1 and sys.argv[1] == "mcp":
        # MCP client mode
        print("Running MCP client...")
        asyncio.run(main())
    else:
        # Classic HTTP streaming client mode
        print("Running classic HTTP streaming client...")
        stream_progress()
        
    # Don't run both by default, let the user choose the mode