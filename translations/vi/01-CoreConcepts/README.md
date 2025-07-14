<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "355b12a5970c5c9e6db0bee970c751ba",
  "translation_date": "2025-07-13T16:12:42+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "vi"
}
-->
# 📖 Khái Niệm Cốt Lõi MCP: Làm Chủ Model Context Protocol cho Tích Hợp AI

[Model Context Protocol (MCP)](https://github.com/modelcontextprotocol) là một khuôn khổ tiêu chuẩn mạnh mẽ giúp tối ưu hóa giao tiếp giữa các Mô hình Ngôn ngữ Lớn (LLMs) và các công cụ, ứng dụng, nguồn dữ liệu bên ngoài. Hướng dẫn tối ưu SEO này sẽ giúp bạn hiểu rõ các khái niệm cốt lõi của MCP, đảm bảo bạn nắm được kiến trúc client-server, các thành phần thiết yếu, cơ chế giao tiếp và các thực hành tốt nhất khi triển khai.

## Tổng Quan

Bài học này khám phá kiến trúc cơ bản và các thành phần tạo nên hệ sinh thái Model Context Protocol (MCP). Bạn sẽ tìm hiểu về kiến trúc client-server, các thành phần chính và cơ chế giao tiếp giúp MCP hoạt động hiệu quả.

## 👩‍🎓 Mục Tiêu Học Tập Chính

Sau bài học này, bạn sẽ:

- Hiểu kiến trúc client-server của MCP.
- Xác định vai trò và trách nhiệm của Hosts, Clients và Servers.
- Phân tích các tính năng cốt lõi giúp MCP trở thành lớp tích hợp linh hoạt.
- Tìm hiểu cách thông tin được truyền tải trong hệ sinh thái MCP.
- Có cái nhìn thực tiễn qua các ví dụ mã nguồn trong .NET, Java, Python và JavaScript.

## 🔎 Kiến Trúc MCP: Cái Nhìn Sâu Hơn

Hệ sinh thái MCP được xây dựng trên mô hình client-server. Cấu trúc mô-đun này cho phép các ứng dụng AI tương tác hiệu quả với công cụ, cơ sở dữ liệu, API và các tài nguyên ngữ cảnh. Hãy cùng phân tích kiến trúc này thành các thành phần cốt lõi.

Ở trung tâm, MCP tuân theo kiến trúc client-server, nơi một ứng dụng host có thể kết nối với nhiều server:

```mermaid
flowchart LR
    subgraph "Your Computer"
        Host["Host with MCP VScode, IDEs, Tools)"]
        S1["MCP Server A"]
        S2["MCP Server B"]
        S3["MCP Server C"]
        Host <-->|"MCP Protocol"| S1
        Host <-->|"MCP Protocol"| S2
        Host <-->|"MCP Protocol"| S3
        S1 <--> D1[("Local\Data Source A")]
        S2 <--> D2[("Local\Data Source B")]
    end
    subgraph "Internet"
        S3 <-->|"Web APIs"| D3[("Remote\Services")]
    end
```

- **MCP Hosts**: Các chương trình như VSCode, Claude Desktop, IDEs hoặc công cụ AI muốn truy cập dữ liệu qua MCP
- **MCP Clients**: Các client giao thức duy trì kết nối 1:1 với server
- **MCP Servers**: Các chương trình nhẹ cung cấp các khả năng cụ thể thông qua Model Context Protocol tiêu chuẩn
- **Nguồn Dữ Liệu Cục Bộ**: Các tệp, cơ sở dữ liệu và dịch vụ trên máy tính của bạn mà MCP servers có thể truy cập an toàn
- **Dịch Vụ Từ Xa**: Các hệ thống bên ngoài có thể truy cập qua internet mà MCP servers kết nối thông qua API.

Giao thức MCP là một tiêu chuẩn đang phát triển, bạn có thể xem các cập nhật mới nhất tại [đặc tả giao thức](https://modelcontextprotocol.io/specification/2025-06-18/)

### 1. Hosts

Trong Model Context Protocol (MCP), Hosts đóng vai trò quan trọng như giao diện chính mà người dùng tương tác với giao thức. Hosts là các ứng dụng hoặc môi trường khởi tạo kết nối với MCP servers để truy cập dữ liệu, công cụ và các prompt. Ví dụ về Hosts bao gồm các môi trường phát triển tích hợp (IDEs) như Visual Studio Code, công cụ AI như Claude Desktop, hoặc các agent tùy chỉnh được thiết kế cho các nhiệm vụ cụ thể.

**Hosts** là các ứng dụng LLM khởi tạo kết nối. Họ:

- Thực thi hoặc tương tác với mô hình AI để tạo phản hồi.
- Khởi tạo kết nối với MCP servers.
- Quản lý luồng hội thoại và giao diện người dùng.
- Kiểm soát quyền hạn và các ràng buộc bảo mật.
- Xử lý sự đồng ý của người dùng về việc chia sẻ dữ liệu và thực thi công cụ.

### 2. Clients

Clients là thành phần thiết yếu giúp tạo điều kiện tương tác giữa Hosts và MCP servers. Clients đóng vai trò trung gian, cho phép Hosts truy cập và sử dụng các chức năng do MCP servers cung cấp. Họ đảm bảo giao tiếp trơn tru và trao đổi dữ liệu hiệu quả trong kiến trúc MCP.

**Clients** là các kết nối bên trong ứng dụng host. Họ:

- Gửi yêu cầu đến server kèm theo prompt/hướng dẫn.
- Thương lượng các khả năng với server.
- Quản lý các yêu cầu thực thi công cụ từ mô hình.
- Xử lý và hiển thị phản hồi cho người dùng.

### 3. Servers

Servers chịu trách nhiệm xử lý các yêu cầu từ MCP clients và cung cấp phản hồi phù hợp. Họ quản lý các hoạt động như truy xuất dữ liệu, thực thi công cụ và tạo prompt. Servers đảm bảo giao tiếp giữa clients và Hosts hiệu quả, đáng tin cậy, duy trì tính toàn vẹn của quá trình tương tác.

**Servers** là các dịch vụ cung cấp ngữ cảnh và khả năng. Họ:

- Đăng ký các tính năng có sẵn (tài nguyên, prompt, công cụ)
- Nhận và thực thi các lệnh gọi công cụ từ client
- Cung cấp thông tin ngữ cảnh để nâng cao phản hồi của mô hình
- Trả kết quả về client
- Duy trì trạng thái qua các tương tác khi cần thiết

Servers có thể được phát triển bởi bất kỳ ai để mở rộng khả năng mô hình với các chức năng chuyên biệt.

### 4. Tính Năng của Server

Servers trong Model Context Protocol (MCP) cung cấp các khối xây dựng cơ bản giúp tương tác phong phú giữa clients, hosts và các mô hình ngôn ngữ. Các tính năng này được thiết kế để nâng cao khả năng của MCP bằng cách cung cấp ngữ cảnh có cấu trúc, công cụ và prompt.

MCP servers có thể cung cấp bất kỳ tính năng nào sau đây:

#### 📑 Tài Nguyên

Tài nguyên trong Model Context Protocol (MCP) bao gồm nhiều loại ngữ cảnh và dữ liệu có thể được người dùng hoặc mô hình AI sử dụng. Bao gồm:

- **Dữ liệu ngữ cảnh**: Thông tin và ngữ cảnh mà người dùng hoặc mô hình AI có thể tận dụng để ra quyết định và thực hiện nhiệm vụ.
- **Cơ sở tri thức và kho tài liệu**: Bộ sưu tập dữ liệu có cấu trúc và không cấu trúc, như bài viết, hướng dẫn, và các bài nghiên cứu, cung cấp thông tin và hiểu biết giá trị.
- **Tệp và cơ sở dữ liệu cục bộ**: Dữ liệu lưu trữ trên thiết bị hoặc trong cơ sở dữ liệu, có thể truy cập để xử lý và phân tích.
- **API và dịch vụ web**: Giao diện và dịch vụ bên ngoài cung cấp dữ liệu và chức năng bổ sung, cho phép tích hợp với nhiều tài nguyên và công cụ trực tuyến.

Ví dụ về một tài nguyên có thể là một sơ đồ cơ sở dữ liệu hoặc một tệp có thể truy cập như sau:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts trong Model Context Protocol (MCP) bao gồm các mẫu và kiểu tương tác được định nghĩa sẵn nhằm đơn giản hóa quy trình làm việc của người dùng và nâng cao giao tiếp. Bao gồm:

- **Tin nhắn và quy trình mẫu**: Các tin nhắn và quy trình được cấu trúc sẵn để hướng dẫn người dùng qua các nhiệm vụ và tương tác cụ thể.
- **Mẫu tương tác định nghĩa trước**: Các chuỗi hành động và phản hồi tiêu chuẩn giúp giao tiếp nhất quán và hiệu quả.
- **Mẫu hội thoại chuyên biệt**: Các mẫu tùy chỉnh dành cho các loại hội thoại cụ thể, đảm bảo tương tác phù hợp và có ngữ cảnh.

Một mẫu prompt có thể trông như sau:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Công Cụ

Công cụ trong Model Context Protocol (MCP) là các hàm mà mô hình AI có thể thực thi để thực hiện các nhiệm vụ cụ thể. Các công cụ này được thiết kế để nâng cao khả năng của mô hình AI bằng cách cung cấp các thao tác có cấu trúc và đáng tin cậy. Các điểm chính bao gồm:

- **Hàm để mô hình AI thực thi**: Công cụ là các hàm có thể gọi để thực hiện các nhiệm vụ khác nhau.
- **Tên và mô tả duy nhất**: Mỗi công cụ có tên riêng và mô tả chi tiết giải thích mục đích và chức năng.
- **Tham số và kết quả**: Công cụ nhận các tham số cụ thể và trả về kết quả có cấu trúc, đảm bảo kết quả nhất quán và dự đoán được.
- **Chức năng riêng biệt**: Công cụ thực hiện các chức năng riêng biệt như tìm kiếm web, tính toán, truy vấn cơ sở dữ liệu.

Ví dụ về một công cụ có thể như sau:

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

## Tính Năng của Client

Trong Model Context Protocol (MCP), clients cung cấp một số tính năng chính cho servers, nâng cao chức năng và tương tác trong giao thức. Một trong những tính năng đáng chú ý là Sampling.

### 👉 Sampling

- **Hành vi tác nhân do server khởi xướng**: Clients cho phép servers khởi xướng các hành động hoặc hành vi cụ thể một cách tự động, tăng cường khả năng động của hệ thống.
- **Tương tác đệ quy với LLM**: Tính năng này cho phép tương tác đệ quy với các mô hình ngôn ngữ lớn (LLMs), giúp xử lý các nhiệm vụ phức tạp và lặp đi lặp lại.
- **Yêu cầu hoàn thành mô hình bổ sung**: Servers có thể yêu cầu thêm các kết quả hoàn thành từ mô hình, đảm bảo phản hồi đầy đủ và phù hợp ngữ cảnh.

## Luồng Thông Tin trong MCP

Model Context Protocol (MCP) định nghĩa luồng thông tin có cấu trúc giữa hosts, clients, servers và các mô hình. Hiểu được luồng này giúp làm rõ cách các yêu cầu của người dùng được xử lý và cách các công cụ, dữ liệu bên ngoài được tích hợp vào phản hồi của mô hình.

- **Host Khởi Tạo Kết Nối**  
  Ứng dụng host (như IDE hoặc giao diện chat) thiết lập kết nối tới MCP server, thường qua STDIO, WebSocket hoặc phương thức truyền tải được hỗ trợ khác.

- **Thương Lượng Khả Năng**  
  Client (nhúng trong host) và server trao đổi thông tin về các tính năng, công cụ, tài nguyên và phiên bản giao thức được hỗ trợ. Điều này đảm bảo cả hai bên hiểu rõ khả năng có sẵn cho phiên làm việc.

- **Yêu Cầu Người Dùng**  
  Người dùng tương tác với host (ví dụ nhập prompt hoặc lệnh). Host thu thập đầu vào này và chuyển cho client xử lý.

- **Sử Dụng Tài Nguyên hoặc Công Cụ**  
  - Client có thể yêu cầu thêm ngữ cảnh hoặc tài nguyên từ server (như tệp, mục cơ sở dữ liệu hoặc bài viết trong kho tri thức) để làm giàu hiểu biết của mô hình.
  - Nếu mô hình xác định cần công cụ (ví dụ để lấy dữ liệu, thực hiện tính toán hoặc gọi API), client gửi yêu cầu gọi công cụ tới server, chỉ định tên công cụ và tham số.

- **Thực Thi Server**  
  Server nhận yêu cầu tài nguyên hoặc công cụ, thực thi các thao tác cần thiết (như chạy hàm, truy vấn cơ sở dữ liệu hoặc lấy tệp), và trả kết quả về client dưới dạng có cấu trúc.

- **Tạo Phản Hồi**  
  Client tích hợp các phản hồi từ server (dữ liệu tài nguyên, kết quả công cụ, v.v.) vào tương tác mô hình đang diễn ra. Mô hình sử dụng thông tin này để tạo phản hồi toàn diện và phù hợp ngữ cảnh.

- **Trình Bày Kết Quả**  
  Host nhận kết quả cuối cùng từ client và hiển thị cho người dùng, thường bao gồm cả văn bản do mô hình tạo ra và các kết quả từ việc thực thi công cụ hoặc tra cứu tài nguyên.

Luồng này cho phép MCP hỗ trợ các ứng dụng AI tương tác nâng cao, có nhận thức ngữ cảnh bằng cách kết nối liền mạch mô hình với công cụ và nguồn dữ liệu bên ngoài.

## Chi Tiết Giao Thức

MCP (Model Context Protocol) được xây dựng trên nền tảng [JSON-RPC 2.0](https://www.jsonrpc.org/), cung cấp định dạng tin nhắn tiêu chuẩn, không phụ thuộc ngôn ngữ cho giao tiếp giữa hosts, clients và servers. Nền tảng này cho phép tương tác đáng tin cậy, có cấu trúc và mở rộng trên nhiều nền tảng và ngôn ngữ lập trình khác nhau.

### Tính Năng Chính của Giao Thức

MCP mở rộng JSON-RPC 2.0 với các quy ước bổ sung cho việc gọi công cụ, truy cập tài nguyên và quản lý prompt. Nó hỗ trợ nhiều lớp truyền tải (STDIO, WebSocket, SSE) và cho phép giao tiếp an toàn, mở rộng, không phụ thuộc ngôn ngữ giữa các thành phần.

#### 🧢 Giao Thức Cơ Bản

- **Định Dạng Tin Nhắn JSON-RPC**: Tất cả yêu cầu và phản hồi sử dụng đặc tả JSON-RPC 2.0, đảm bảo cấu trúc nhất quán cho các cuộc gọi phương thức, tham số, kết quả và xử lý lỗi.
- **Kết Nối Có Trạng Thái**: Phiên MCP duy trì trạng thái qua nhiều yêu cầu, hỗ trợ hội thoại liên tục, tích lũy ngữ cảnh và quản lý tài nguyên.
- **Thương Lượng Khả Năng**: Trong quá trình thiết lập kết nối, clients và servers trao đổi thông tin về các tính năng được hỗ trợ, phiên bản giao thức, công cụ và tài nguyên có sẵn. Điều này đảm bảo cả hai bên hiểu rõ khả năng của nhau và có thể điều chỉnh phù hợp.

#### ➕ Tiện Ích Bổ Sung

Dưới đây là một số tiện ích và mở rộng giao thức mà MCP cung cấp để nâng cao trải nghiệm nhà phát triển và hỗ trợ các kịch bản nâng cao:

- **Tùy Chỉnh Cấu Hình**: MCP cho phép cấu hình động các tham số phiên làm việc, như quyền công cụ, truy cập tài nguyên và cài đặt mô hình, phù hợp với từng tương tác.
- **Theo Dõi Tiến Độ**: Các thao tác chạy lâu có thể báo cáo tiến độ, giúp giao diện người dùng phản hồi nhanh và cải thiện trải nghiệm trong các tác vụ phức tạp.
- **Hủy Yêu Cầu**: Clients có thể hủy các yêu cầu đang thực hiện, cho phép người dùng ngắt các thao tác không còn cần thiết hoặc mất quá nhiều thời gian.
- **Báo Cáo Lỗi**: Các thông báo lỗi và mã lỗi tiêu chuẩn giúp chẩn đoán sự cố, xử lý lỗi một cách mượt mà và cung cấp phản hồi hữu ích cho người dùng và nhà phát triển.
- **Ghi Nhật Ký**: Cả clients và servers có thể phát ra các bản ghi có cấu trúc để kiểm toán, gỡ lỗi và giám sát các tương tác giao thức.

Bằng cách tận dụng các tính năng giao thức này, MCP đảm bảo giao tiếp mạnh mẽ, an toàn và linh hoạt giữa các mô hình ngôn ngữ và công cụ hoặc nguồn dữ liệu bên ngoài.

### 🔐 Các Vấn Đề Bảo Mật

Các triển khai MCP nên tuân thủ một số nguyên tắc bảo mật quan trọng để đảm bảo các tương tác an toàn và đáng tin cậy:

- **Sự Đồng Ý và Kiểm Soát của Người Dùng**: Người dùng phải cung cấp sự đồng ý rõ ràng trước khi bất kỳ dữ liệu nào được truy cập hoặc thao tác được thực hiện. Họ cần có quyền kiểm soát rõ ràng về dữ liệu được chia sẻ và các hành động được phép, được hỗ trợ bởi giao diện người dùng trực quan để xem xét và phê duyệt hoạt động.

- **Bảo Mật Dữ Liệu**: Dữ liệu người dùng chỉ được tiết lộ khi có sự đồng ý rõ ràng và phải được bảo vệ bằng các kiểm soát truy cập phù hợp. Các triển khai MCP phải ngăn chặn việc truyền dữ liệu trái phép và đảm bảo quyền riêng tư được duy trì trong suốt các tương tác.

- **An Toàn Công Cụ**: Trước khi gọi bất kỳ công cụ nào, cần có sự đồng ý rõ ràng của người dùng. Người dùng cần hiểu rõ chức năng của từng công cụ, và các ranh giới bảo mật nghiêm ngặt phải được thực thi để ngăn chặn việc thực thi công cụ không mong muốn hoặc không an toàn.

Bằng cách tuân thủ các nguyên tắc này, MCP đảm bảo sự tin tưởng, quyền riêng tư và an toàn của người dùng trong tất cả các tương tác giao thức.

## Ví Dụ Mã Nguồn: Các Thành Phần Chính

Dưới đây là các ví dụ mã nguồn trong một số ngôn ngữ lập trình phổ biến minh họa cách triển khai các thành phần server MCP và công cụ.

### Ví Dụ .NET: Tạo MCP Server Đơn Giản với Công Cụ

Đây là ví dụ mã .NET thực tế minh họa cách triển khai một MCP server đơn giản với các công cụ tùy chỉnh. Ví dụ này trình bày cách định nghĩa và đăng ký công cụ, xử lý yêu cầu và kết nối server sử dụng Model Context Protocol.

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

### Ví Dụ Java: Thành Phần MCP Server

Ví dụ này trình bày cùng một MCP server và đăng ký công cụ như ví dụ .NET ở trên, nhưng được triển khai bằng Java.

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

### Ví Dụ Python: Xây Dựng MCP Server

Trong ví dụ này, chúng tôi trình bày cách xây dựng một MCP server bằng Python. Bạn cũng sẽ thấy hai cách khác nhau để tạo công cụ.

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

# Instantiate the class to register its tools
weather_tools = WeatherTools()

# Start the server using stdio transport
if __name__ == "__main__":
    asyncio.run(serve_stdio(mcp))
```

### Ví Dụ JavaScript: Tạo MCP Server

Ví dụ này cho thấy cách tạo MCP server bằng JavaScript và cách đăng ký hai công cụ liên quan đến thời tiết.

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

Ví dụ JavaScript này minh họa cách tạo một MCP client kết nối tới server, gửi prompt và xử lý phản hồi bao gồm cả các cuộc gọi công cụ đã thực hiện.

## Bảo Mật và Ủy Quyền
MCP bao gồm một số khái niệm và cơ chế tích hợp sẵn để quản lý bảo mật và ủy quyền trong toàn bộ giao thức:

1. **Kiểm soát Quyền Công cụ**:  
  Khách hàng có thể chỉ định những công cụ mà một mô hình được phép sử dụng trong suốt phiên làm việc. Điều này đảm bảo chỉ những công cụ được cấp quyền rõ ràng mới có thể truy cập, giảm thiểu rủi ro thực hiện các thao tác không mong muốn hoặc không an toàn. Quyền truy cập có thể được cấu hình linh hoạt dựa trên sở thích người dùng, chính sách tổ chức hoặc bối cảnh tương tác.

2. **Xác thực**:  
  Máy chủ có thể yêu cầu xác thực trước khi cấp quyền truy cập vào công cụ, tài nguyên hoặc các thao tác nhạy cảm. Việc này có thể bao gồm khóa API, token OAuth hoặc các phương thức xác thực khác. Xác thực đúng cách đảm bảo chỉ những khách hàng và người dùng đáng tin cậy mới có thể sử dụng các khả năng phía máy chủ.

3. **Kiểm tra hợp lệ**:  
  Việc kiểm tra tham số được thực thi cho tất cả các lần gọi công cụ. Mỗi công cụ định nghĩa các kiểu dữ liệu, định dạng và ràng buộc mong đợi cho các tham số của nó, và máy chủ sẽ kiểm tra các yêu cầu đến dựa trên đó. Điều này ngăn chặn dữ liệu đầu vào sai định dạng hoặc có ý đồ xấu tiếp cận các triển khai công cụ, đồng thời giúp duy trì tính toàn vẹn của các thao tác.

4. **Giới hạn tần suất**:  
  Để ngăn chặn việc lạm dụng và đảm bảo sử dụng tài nguyên máy chủ công bằng, các máy chủ MCP có thể áp dụng giới hạn tần suất cho các cuộc gọi công cụ và truy cập tài nguyên. Giới hạn này có thể áp dụng theo người dùng, theo phiên hoặc toàn cục, giúp bảo vệ chống lại các cuộc tấn công từ chối dịch vụ hoặc tiêu thụ tài nguyên quá mức.

Bằng cách kết hợp các cơ chế này, MCP cung cấp nền tảng an toàn để tích hợp các mô hình ngôn ngữ với công cụ và nguồn dữ liệu bên ngoài, đồng thời cho phép người dùng và nhà phát triển kiểm soát chi tiết quyền truy cập và cách sử dụng.

## Tin nhắn Giao thức

Giao tiếp MCP sử dụng các tin nhắn JSON có cấu trúc để tạo điều kiện cho các tương tác rõ ràng và đáng tin cậy giữa khách hàng, máy chủ và mô hình. Các loại tin nhắn chính bao gồm:

- **Yêu cầu từ Khách hàng**  
  Được gửi từ khách hàng đến máy chủ, tin nhắn này thường bao gồm:
  - Lời nhắc hoặc lệnh của người dùng
  - Lịch sử cuộc trò chuyện để cung cấp ngữ cảnh
  - Cấu hình và quyền truy cập công cụ
  - Bất kỳ siêu dữ liệu hoặc thông tin phiên bổ sung nào

- **Phản hồi từ Mô hình**  
  Được trả về bởi mô hình (thông qua khách hàng), tin nhắn này chứa:
  - Văn bản được tạo ra hoặc kết quả hoàn thành dựa trên lời nhắc và ngữ cảnh
  - Hướng dẫn gọi công cụ tùy chọn nếu mô hình xác định cần sử dụng công cụ
  - Tham chiếu đến tài nguyên hoặc ngữ cảnh bổ sung khi cần

- **Yêu cầu Công cụ**  
  Được gửi từ khách hàng đến máy chủ khi cần thực thi một công cụ. Tin nhắn này bao gồm:
  - Tên công cụ cần gọi
  - Các tham số mà công cụ yêu cầu (được kiểm tra theo sơ đồ của công cụ)
  - Thông tin ngữ cảnh hoặc định danh để theo dõi yêu cầu

- **Phản hồi Công cụ**  
  Được trả về bởi máy chủ sau khi thực thi công cụ. Tin nhắn này cung cấp:
  - Kết quả của việc thực thi công cụ (dữ liệu có cấu trúc hoặc nội dung)
  - Bất kỳ lỗi hoặc thông tin trạng thái nào nếu cuộc gọi công cụ thất bại
  - Tùy chọn, siêu dữ liệu hoặc nhật ký liên quan đến quá trình thực thi

Các tin nhắn có cấu trúc này đảm bảo mỗi bước trong quy trình MCP đều rõ ràng, có thể truy vết và mở rộng, hỗ trợ các kịch bản nâng cao như hội thoại nhiều lượt, chuỗi công cụ và xử lý lỗi mạnh mẽ.

## Những điểm chính cần nhớ

- MCP sử dụng kiến trúc khách hàng - máy chủ để kết nối các mô hình với các khả năng bên ngoài
- Hệ sinh thái bao gồm khách hàng, máy chủ lưu trữ, máy chủ, công cụ và nguồn dữ liệu
- Giao tiếp có thể diễn ra qua STDIO, SSE hoặc WebSockets
- Công cụ là đơn vị chức năng cơ bản được cung cấp cho các mô hình
- Giao thức giao tiếp có cấu trúc đảm bảo các tương tác nhất quán

## Bài tập

Thiết kế một công cụ MCP đơn giản mà bạn thấy hữu ích trong lĩnh vực của mình. Xác định:
1. Tên công cụ sẽ là gì
2. Các tham số mà công cụ sẽ nhận
3. Kết quả đầu ra mà công cụ sẽ trả về
4. Cách một mô hình có thể sử dụng công cụ này để giải quyết vấn đề của người dùng


---

## Tiếp theo

Tiếp theo: [Chapter 2: Security](../02-Security/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.