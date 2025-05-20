<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:42:09+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "vi"
}
-->
# 📖 Khái Niệm Cốt Lõi MCP: Làm Chủ Giao Thức Ngữ Cảnh Mô Hình cho Tích Hợp AI

Giao Thức Ngữ Cảnh Mô Hình (MCP) là một khuôn khổ chuẩn hóa mạnh mẽ giúp tối ưu hóa giao tiếp giữa Các Mô Hình Ngôn Ngữ Lớn (LLMs) với các công cụ, ứng dụng và nguồn dữ liệu bên ngoài. Hướng dẫn được tối ưu SEO này sẽ giúp bạn hiểu rõ các khái niệm cốt lõi của MCP, đảm bảo bạn nắm bắt kiến trúc client-server, các thành phần thiết yếu, cơ chế giao tiếp và các thực hành tốt nhất khi triển khai.

## Tổng Quan

Bài học này khám phá kiến trúc cơ bản và các thành phần cấu thành hệ sinh thái Giao Thức Ngữ Cảnh Mô Hình (MCP). Bạn sẽ tìm hiểu về kiến trúc client-server, các thành phần chính và cơ chế giao tiếp giúp vận hành các tương tác MCP.

## 👩‍🎓 Mục Tiêu Học Tập Chính

Sau bài học này, bạn sẽ:

- Hiểu kiến trúc client-server của MCP.
- Xác định vai trò và trách nhiệm của Hosts, Clients và Servers.
- Phân tích các tính năng cốt lõi làm MCP trở thành lớp tích hợp linh hoạt.
- Tìm hiểu cách thông tin luân chuyển trong hệ sinh thái MCP.
- Nắm được các ví dụ thực tiễn bằng .NET, Java, Python và JavaScript.

## 🔎 Kiến Trúc MCP: Nhìn Sâu Hơn

Hệ sinh thái MCP được xây dựng trên mô hình client-server. Cấu trúc mô-đun này cho phép các ứng dụng AI tương tác hiệu quả với công cụ, cơ sở dữ liệu, API và các tài nguyên ngữ cảnh. Hãy cùng phân tích kiến trúc này thành các thành phần cốt lõi.

### 1. Hosts

Trong Giao Thức Ngữ Cảnh Mô Hình (MCP), Hosts đóng vai trò quan trọng như giao diện chính mà người dùng tương tác với giao thức. Hosts là các ứng dụng hoặc môi trường khởi tạo kết nối với các server MCP để truy cập dữ liệu, công cụ và các lời nhắc. Ví dụ về Hosts bao gồm các môi trường phát triển tích hợp (IDE) như Visual Studio Code, các công cụ AI như Claude Desktop, hoặc các agent tự xây dựng cho các nhiệm vụ cụ thể.

**Hosts** là các ứng dụng LLM khởi tạo kết nối. Họ:

- Thực thi hoặc tương tác với mô hình AI để tạo phản hồi.
- Khởi tạo kết nối với các server MCP.
- Quản lý luồng hội thoại và giao diện người dùng.
- Kiểm soát quyền và các giới hạn bảo mật.
- Xử lý sự đồng ý của người dùng về chia sẻ dữ liệu và thực thi công cụ.

### 2. Clients

Clients là thành phần thiết yếu giúp tạo điều kiện tương tác giữa Hosts và các server MCP. Clients đóng vai trò trung gian, cho phép Hosts truy cập và sử dụng các chức năng do server MCP cung cấp. Họ đóng vai trò quan trọng trong việc đảm bảo giao tiếp trơn tru và trao đổi dữ liệu hiệu quả trong kiến trúc MCP.

**Clients** là các bộ kết nối bên trong ứng dụng host. Họ:

- Gửi yêu cầu đến server với lời nhắc hoặc hướng dẫn.
- Đàm phán khả năng với server.
- Quản lý các yêu cầu thực thi công cụ từ mô hình.
- Xử lý và hiển thị phản hồi cho người dùng.

### 3. Servers

Servers chịu trách nhiệm xử lý các yêu cầu từ client MCP và cung cấp phản hồi phù hợp. Họ quản lý các hoạt động như truy xuất dữ liệu, thực thi công cụ và tạo lời nhắc. Servers đảm bảo giao tiếp giữa client và host diễn ra hiệu quả và tin cậy, duy trì tính toàn vẹn của quá trình tương tác.

**Servers** là các dịch vụ cung cấp ngữ cảnh và khả năng. Họ:

- Đăng ký các tính năng sẵn có (nguồn lực, lời nhắc, công cụ).
- Nhận và thực thi các cuộc gọi công cụ từ client.
- Cung cấp thông tin ngữ cảnh để nâng cao phản hồi của mô hình.
- Trả kết quả về client.
- Duy trì trạng thái qua các tương tác khi cần thiết.

Servers có thể được phát triển bởi bất kỳ ai để mở rộng khả năng mô hình với chức năng chuyên biệt.

### 4. Tính Năng Server

Servers trong Giao Thức Ngữ Cảnh Mô Hình (MCP) cung cấp các khối xây dựng cơ bản giúp tương tác phong phú giữa client, host và mô hình ngôn ngữ. Những tính năng này được thiết kế để nâng cao khả năng của MCP bằng cách cung cấp ngữ cảnh có cấu trúc, công cụ và lời nhắc.

Servers MCP có thể cung cấp bất kỳ tính năng nào sau đây:

#### 📑 Nguồn Lực

Nguồn lực trong Giao Thức Ngữ Cảnh Mô Hình (MCP) bao gồm nhiều loại ngữ cảnh và dữ liệu có thể được người dùng hoặc mô hình AI sử dụng. Bao gồm:

- **Dữ liệu Ngữ Cảnh**: Thông tin và ngữ cảnh mà người dùng hoặc mô hình AI có thể tận dụng để ra quyết định và thực hiện nhiệm vụ.
- **Cơ sở Kiến Thức và Kho Tài Liệu**: Bộ sưu tập dữ liệu có cấu trúc và không có cấu trúc, như bài báo, hướng dẫn và tài liệu nghiên cứu, cung cấp những hiểu biết và thông tin giá trị.
- **Tệp và Cơ sở Dữ liệu Cục bộ**: Dữ liệu lưu trữ cục bộ trên thiết bị hoặc trong cơ sở dữ liệu, có thể truy cập để xử lý và phân tích.
- **API và Dịch vụ Web**: Giao diện và dịch vụ bên ngoài cung cấp dữ liệu và chức năng bổ sung, cho phép tích hợp với nhiều nguồn tài nguyên và công cụ trực tuyến.

Ví dụ về một nguồn lực có thể là một sơ đồ cơ sở dữ liệu hoặc một tệp có thể truy cập như sau:

```text
file://log.txt
database://schema
```

### 🤖 Lời Nhắc

Lời nhắc trong Giao Thức Ngữ Cảnh Mô Hình (MCP) bao gồm các mẫu và kiểu tương tác được định nghĩa trước nhằm đơn giản hóa quy trình làm việc của người dùng và nâng cao giao tiếp. Bao gồm:

- **Thông điệp và Quy trình có Mẫu**: Các thông điệp và quy trình được cấu trúc sẵn giúp hướng dẫn người dùng qua các nhiệm vụ và tương tác cụ thể.
- **Mẫu Tương Tác Định Nghĩa Trước**: Các chuỗi hành động và phản hồi chuẩn hóa giúp giao tiếp nhất quán và hiệu quả.
- **Mẫu Hội Thoại Chuyên Biệt**: Các mẫu tùy chỉnh dành cho các loại hội thoại cụ thể, đảm bảo tương tác phù hợp và có ngữ cảnh.

Một mẫu lời nhắc có thể trông như sau:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Công Cụ

Công cụ trong Giao Thức Ngữ Cảnh Mô Hình (MCP) là các hàm mà mô hình AI có thể thực thi để thực hiện các nhiệm vụ cụ thể. Những công cụ này được thiết kế để nâng cao khả năng của mô hình AI bằng cách cung cấp các thao tác có cấu trúc và đáng tin cậy. Các điểm chính bao gồm:

- **Hàm để mô hình AI thực thi**: Công cụ là các hàm có thể gọi để thực hiện nhiều nhiệm vụ khác nhau.
- **Tên và Mô tả Độc nhất**: Mỗi công cụ có tên riêng biệt và mô tả chi tiết giải thích mục đích và chức năng.
- **Tham số và Kết quả**: Công cụ nhận các tham số cụ thể và trả về kết quả có cấu trúc, đảm bảo tính nhất quán và dự đoán được.
- **Hàm Riêng biệt**: Công cụ thực hiện các chức năng riêng biệt như tìm kiếm web, tính toán, truy vấn cơ sở dữ liệu.

Ví dụ về một công cụ có thể trông như sau:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Tính Năng Client

Trong Giao Thức Ngữ Cảnh Mô Hình (MCP), client cung cấp một số tính năng chính cho server, nâng cao chức năng tổng thể và tương tác trong giao thức. Một trong những tính năng đáng chú ý là Sampling.

### 👉 Sampling

- **Hành Vi Chủ Động do Server Khởi Xướng**: Client cho phép server khởi xướng các hành động hoặc hành vi cụ thể một cách tự động, nâng cao khả năng động của hệ thống.
- **Tương Tác Lặp lại với LLM**: Tính năng này cho phép tương tác lặp lại với các mô hình ngôn ngữ lớn, giúp xử lý các nhiệm vụ phức tạp và lặp đi lặp lại.
- **Yêu Cầu Hoàn Thành Mô Hình Bổ Sung**: Server có thể yêu cầu các kết quả bổ sung từ mô hình, đảm bảo phản hồi đầy đủ và phù hợp ngữ cảnh.

## Luồng Thông Tin trong MCP

Giao Thức Ngữ Cảnh Mô Hình (MCP) định nghĩa luồng thông tin có cấu trúc giữa host, client, server và mô hình. Hiểu rõ luồng này giúp làm sáng tỏ cách xử lý yêu cầu người dùng và cách các công cụ, dữ liệu bên ngoài được tích hợp vào phản hồi của mô hình.

- **Host Khởi Tạo Kết Nối**  
  Ứng dụng host (chẳng hạn như IDE hoặc giao diện chat) thiết lập kết nối đến server MCP, thường qua STDIO, WebSocket hoặc một phương thức truyền tải được hỗ trợ khác.

- **Đàm Phán Khả Năng**  
  Client (nhúng trong host) và server trao đổi thông tin về các tính năng, công cụ, nguồn lực và phiên bản giao thức được hỗ trợ. Điều này đảm bảo cả hai bên hiểu được khả năng có sẵn cho phiên làm việc.

- **Yêu Cầu Người Dùng**  
  Người dùng tương tác với host (ví dụ, nhập lời nhắc hoặc lệnh). Host thu thập đầu vào này và chuyển cho client xử lý.

- **Sử Dụng Nguồn Lực hoặc Công Cụ**  
  - Client có thể yêu cầu thêm ngữ cảnh hoặc nguồn lực từ server (như tệp, bản ghi cơ sở dữ liệu hoặc bài viết trong cơ sở kiến thức) để làm phong phú thêm hiểu biết của mô hình.
  - Nếu mô hình xác định cần công cụ (ví dụ, để lấy dữ liệu, thực hiện tính toán hoặc gọi API), client gửi yêu cầu gọi công cụ đến server, chỉ định tên công cụ và tham số.

- **Thực Thi Server**  
  Server nhận yêu cầu nguồn lực hoặc công cụ, thực thi các thao tác cần thiết (chạy hàm, truy vấn cơ sở dữ liệu hoặc lấy tệp) và trả kết quả về client dưới dạng có cấu trúc.

- **Tạo Phản Hồi**  
  Client tích hợp phản hồi từ server (dữ liệu nguồn lực, kết quả công cụ, v.v.) vào tương tác mô hình đang diễn ra. Mô hình sử dụng thông tin này để tạo phản hồi đầy đủ và phù hợp ngữ cảnh.

- **Hiển Thị Kết Quả**  
  Host nhận kết quả cuối cùng từ client và trình bày cho người dùng, thường bao gồm cả văn bản do mô hình tạo và các kết quả từ công cụ hoặc truy xuất nguồn lực.

Luồng này cho phép MCP hỗ trợ các ứng dụng AI tương tác nâng cao, có nhận thức ngữ cảnh bằng cách kết nối liền mạch mô hình với các công cụ và nguồn dữ liệu bên ngoài.

## Chi Tiết Giao Thức

MCP (Model Context Protocol) được xây dựng trên nền tảng [JSON-RPC 2.0](https://www.jsonrpc.org/), cung cấp định dạng thông điệp chuẩn, không phụ thuộc ngôn ngữ để giao tiếp giữa host, client và server. Nền tảng này đảm bảo các tương tác có cấu trúc, tin cậy và mở rộng trên nhiều nền tảng và ngôn ngữ lập trình khác nhau.

### Tính Năng Chính của Giao Thức

MCP mở rộng JSON-RPC 2.0 với các quy ước bổ sung cho việc gọi công cụ, truy cập nguồn lực và quản lý lời nhắc. Nó hỗ trợ nhiều lớp truyền tải (STDIO, WebSocket, SSE) và cho phép giao tiếp an toàn, mở rộng, không phụ thuộc ngôn ngữ giữa các thành phần.

#### 🧢 Giao Thức Cơ Bản

- **Định Dạng Thông Điệp JSON-RPC**: Tất cả yêu cầu và phản hồi sử dụng đặc tả JSON-RPC 2.0, đảm bảo cấu trúc nhất quán cho các cuộc gọi phương thức, tham số, kết quả và xử lý lỗi.
- **Kết Nối Có Trạng Thái**: Phiên MCP duy trì trạng thái qua nhiều yêu cầu, hỗ trợ hội thoại liên tục, tích lũy ngữ cảnh và quản lý nguồn lực.
- **Đàm Phán Khả Năng**: Trong quá trình thiết lập kết nối, client và server trao đổi thông tin về các tính năng được hỗ trợ, phiên bản giao thức, công cụ và nguồn lực có sẵn. Điều này giúp cả hai bên hiểu và thích ứng với khả năng của nhau.

#### ➕ Tiện Ích Bổ Sung

Dưới đây là một số tiện ích và phần mở rộng giao thức mà MCP cung cấp nhằm nâng cao trải nghiệm nhà phát triển và hỗ trợ các kịch bản nâng cao:

- **Tùy Chỉnh Cấu Hình**: MCP cho phép cấu hình động các tham số phiên làm việc, như quyền công cụ, truy cập nguồn lực và thiết lập mô hình, phù hợp với từng tương tác.
- **Theo Dõi Tiến Trình**: Các thao tác tốn thời gian có thể báo cáo tiến độ, giúp giao diện người dùng phản hồi nhanh và trải nghiệm tốt hơn trong các nhiệm vụ phức tạp.
- **Hủy Yêu Cầu**: Client có thể hủy các yêu cầu đang thực hiện, cho phép người dùng ngắt các thao tác không còn cần thiết hoặc mất quá nhiều thời gian.
- **Báo Cáo Lỗi**: Các thông điệp và mã lỗi chuẩn hóa giúp chẩn đoán sự cố, xử lý thất bại một cách nhẹ nhàng và cung cấp phản hồi hữu ích cho người dùng và nhà phát triển.
- **Ghi Nhận Nhật Ký**: Cả client và server có thể phát ra các bản ghi có cấu trúc để kiểm toán, gỡ lỗi và giám sát các tương tác giao thức.

Bằng cách tận dụng các tính năng này, MCP đảm bảo giao tiếp mạnh mẽ, an toàn và linh hoạt giữa các mô hình ngôn ngữ và công cụ hoặc nguồn dữ liệu bên ngoài.

### 🔐 Cân Nhắc Bảo Mật

Các triển khai MCP cần tuân thủ một số nguyên tắc bảo mật chính để đảm bảo các tương tác an toàn và đáng tin cậy:

- **Sự Đồng Ý và Kiểm Soát của Người Dùng**: Người dùng phải cung cấp sự đồng ý rõ ràng trước khi bất kỳ dữ liệu nào được truy cập hoặc thao tác được thực hiện. Họ cần có quyền kiểm soát rõ ràng về dữ liệu được chia sẻ và các hành động được phép, kèm theo giao diện người dùng trực quan để xem xét và phê duyệt các hoạt động.

- **Bảo Mật Dữ Liệu**: Dữ liệu người dùng chỉ được tiết lộ khi có sự đồng ý rõ ràng và phải được bảo vệ bằng các cơ chế kiểm soát truy cập phù hợp. Các triển khai MCP phải bảo vệ chống truyền dữ liệu trái phép và đảm bảo quyền riêng tư trong suốt các tương tác.

- **An Toàn Công Cụ**: Trước khi gọi bất kỳ công cụ nào, cần có sự đồng ý rõ ràng của người dùng. Người dùng nên hiểu rõ chức năng của từng công cụ, đồng thời các biên giới bảo mật nghiêm ngặt phải được thực thi để ngăn chặn việc thực thi công cụ không an toàn hoặc ngoài ý muốn.

Bằng cách tuân thủ các nguyên tắc này, MCP đảm bảo sự tin tưởng, quyền riêng tư và an toàn của người dùng trong toàn bộ các tương tác giao thức.

## Ví Dụ Mã Nguồn: Các Thành Phần Chính

Dưới đây là các ví dụ mã nguồn trong một số ngôn ngữ lập trình phổ biến minh họa cách triển khai các thành phần server MCP và công cụ.

### Ví Dụ .NET: Tạo Server MCP Đơn Giản với Công Cụ

Đây là ví dụ mã .NET thực tế minh họa cách triển khai một server MCP đơn giản với các công cụ tùy chỉnh. Ví dụ này trình bày cách định nghĩa và đăng ký công cụ, xử lý yêu cầu và kết nối server sử dụng Giao Thức Ngữ Cảnh Mô Hình.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Ví Dụ Java: Thành Phần Server MCP

Ví dụ này minh họa cùng server MCP và đăng ký công cụ như ví dụ .NET ở trên, nhưng được triển khai bằng Java.

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### Ví Dụ Python: Xây Dựng Server MCP

Trong ví dụ này, chúng tôi trình bày cách xây dựng server MCP bằng Python. Bạn cũng sẽ thấy hai cách khác nhau để tạo công cụ.

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### Ví Dụ JavaScript: Tạo Server MCP

Ví dụ này cho thấy cách tạo server MCP bằng JavaScript và cách đăng ký hai công cụ liên quan đến thời tiết.

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

Ví dụ JavaScript này minh họa cách tạo client MCP kết nối đến server, gửi lời nhắc và xử lý phản hồi bao gồm cả các cuộc gọi công cụ được thực hiện.

## Bảo Mật và Ủy Quyền

MCP bao gồm nhiều khái niệm và cơ chế tích hợp để quản lý bảo mật và ủy quyền trong toàn bộ giao thức:

1. **Kiểm Soát Quyền Công Cụ**:  
  Client có thể chỉ định các công cụ mà mô hình được phép sử dụng trong phiên làm việc. Điều này đảm bảo chỉ những công cụ được phép rõ ràng mới có thể truy cập, giảm nguy cơ thao tác ngoài ý muốn hoặc không an toàn. Quyền có thể được cấu hình động dựa trên sở thích người dùng, chính sách tổ chức hoặc ngữ cảnh tương tác.

2. **Xác Thực**:  
  Server có thể yêu cầu xác thực trước khi cấp quyền truy cập công cụ, nguồn lực hoặc các thao tác nhạy cảm. Điều này có

**Tuyên bố miễn trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn thông tin chính xác nhất. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.