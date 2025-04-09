import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

/**
 * Sample MCP Calculator Server implementation in Java.
 * 
 * This class demonstrates how to create a simple MCP server with calculator tools
 * that can perform basic arithmetic operations (add, subtract, multiply, divide).
 */
public class McpCalculatorServer {

    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Calculator MCP Server")
            .version("1.0.0")
            .build();
        
        // Define calculator tools for each operation
        server.registerTool(McpToolDefinition.builder("add")
            .description("Add two numbers together")
            .parameter("a", Double.class)
            .parameter("b", Double.class)
            .execute((ToolExecutionContext ctx) -> {
                double a = ctx.getParameter("a", Double.class);
                double b = ctx.getParameter("b", Double.class);
                return ToolResponse.content(String.valueOf(a + b));
            })
            .build());
            
        server.registerTool(McpToolDefinition.builder("subtract")
            .description("Subtract b from a")
            .parameter("a", Double.class)
            .parameter("b", Double.class)
            .execute((ToolExecutionContext ctx) -> {
                double a = ctx.getParameter("a", Double.class);
                double b = ctx.getParameter("b", Double.class);
                return ToolResponse.content(String.valueOf(a - b));
            })
            .build());
            
        server.registerTool(McpToolDefinition.builder("multiply")
            .description("Multiply two numbers together")
            .parameter("a", Double.class)
            .parameter("b", Double.class)
            .execute((ToolExecutionContext ctx) -> {
                double a = ctx.getParameter("a", Double.class);
                double b = ctx.getParameter("b", Double.class);
                return ToolResponse.content(String.valueOf(a * b));
            })
            .build());
            
        server.registerTool(McpToolDefinition.builder("divide")
            .description("Divide a by b")
            .parameter("a", Double.class)
            .parameter("b", Double.class)
            .execute((ToolExecutionContext ctx) -> {
                double a = ctx.getParameter("a", Double.class);
                double b = ctx.getParameter("b", Double.class);
                
                if (b == 0) {
                    return ToolResponse.error("Cannot divide by zero");
                }
                
                return ToolResponse.content(String.valueOf(a / b));
            })
            .build());
            
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Calculator MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
}
