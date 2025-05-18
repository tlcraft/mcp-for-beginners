<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:49:07+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "vi"
}
-->
# 📖 Các Khái Niệm Cốt Lõi MCP: Làm Chủ Giao Thức Ngữ Cảnh Mô Hình cho Tích Hợp AI

Giao Thức Ngữ Cảnh Mô Hình (MCP) là một khung chuẩn hóa mạnh mẽ tối ưu hóa giao tiếp giữa các Mô Hình Ngôn Ngữ Lớn (LLM) và các công cụ, ứng dụng, và nguồn dữ liệu bên ngoài. Hướng dẫn tối ưu hóa SEO này sẽ dẫn bạn qua các khái niệm cốt lõi của MCP, đảm bảo bạn hiểu kiến trúc khách-chủ, các thành phần thiết yếu, cơ chế giao tiếp, và các thực tiễn tốt nhất trong việc triển khai.

## Tổng Quan

Bài học này khám phá kiến trúc cơ bản và các thành phần tạo nên hệ sinh thái Giao Thức Ngữ Cảnh Mô Hình (MCP). Bạn sẽ học về kiến trúc khách-chủ, các thành phần chính, và các cơ chế giao tiếp thúc đẩy các tương tác MCP.

## 👩‍🎓 Mục Tiêu Học Tập Chính

Cuối bài học này, bạn sẽ:

- Hiểu kiến trúc khách-chủ của MCP.
- Xác định vai trò và trách nhiệm của Máy chủ, Khách hàng, và Máy chủ.
- Phân tích các tính năng cốt lõi làm cho MCP trở thành một lớp tích hợp linh hoạt.
- Học cách thông tin lưu chuyển trong hệ sinh thái MCP.
- Nhận được những hiểu biết thực tế qua các ví dụ mã trong .NET, Java, Python, và JavaScript.

## 🔎 Kiến Trúc MCP: Một Cái Nhìn Sâu Hơn

Hệ sinh thái MCP được xây dựng trên mô hình khách-chủ. Cấu trúc mô-đun này cho phép các ứng dụng AI tương tác với các công cụ, cơ sở dữ liệu, API, và các nguồn tài nguyên ngữ cảnh một cách hiệu quả. Hãy cùng phân tích kiến trúc này thành các thành phần cốt lõi.

### 1. Máy chủ

Trong Giao Thức Ngữ Cảnh Mô Hình (MCP), Máy chủ đóng vai trò quan trọng như giao diện chính mà qua đó người dùng tương tác với giao thức. Máy chủ là các ứng dụng hoặc môi trường khởi tạo kết nối với các máy chủ MCP để truy cập dữ liệu, công cụ, và lời nhắc. Ví dụ về Máy chủ bao gồm các môi trường phát triển tích hợp (IDE) như Visual Studio Code, các công cụ AI như Claude Desktop, hoặc các tác nhân tùy chỉnh được thiết kế cho các nhiệm vụ cụ thể.

**Máy chủ** là các ứng dụng LLM khởi tạo kết nối. Chúng:

- Thực thi hoặc tương tác với các mô hình AI để tạo ra phản hồi.
- Khởi tạo kết nối với các máy chủ MCP.
- Quản lý luồng hội thoại và giao diện người dùng.
- Kiểm soát quyền hạn và các ràng buộc bảo mật.
- Xử lý sự đồng ý của người dùng cho việc chia sẻ dữ liệu và thực thi công cụ.

### 2. Khách hàng

Khách hàng là các thành phần thiết yếu tạo điều kiện cho sự tương tác giữa Máy chủ và các máy chủ MCP. Khách hàng hoạt động như các trung gian, cho phép Máy chủ truy cập và sử dụng các chức năng được cung cấp bởi các máy chủ MCP. Chúng đóng vai trò quan trọng trong việc đảm bảo giao tiếp suôn sẻ và trao đổi dữ liệu hiệu quả trong kiến trúc MCP.

**Khách hàng** là các kết nối trong ứng dụng máy chủ. Chúng:

- Gửi yêu cầu đến các máy chủ với các lời nhắc/hướng dẫn.
- Đàm phán khả năng với các máy chủ.
- Quản lý các yêu cầu thực thi công cụ từ các mô hình.
- Xử lý và hiển thị phản hồi cho người dùng.

### 3. Máy chủ

Máy chủ chịu trách nhiệm xử lý các yêu cầu từ khách hàng MCP và cung cấp các phản hồi thích hợp. Chúng quản lý các hoạt động khác nhau như truy xuất dữ liệu, thực thi công cụ, và tạo lời nhắc. Máy chủ đảm bảo rằng giao tiếp giữa khách hàng và Máy chủ là hiệu quả và đáng tin cậy, duy trì tính toàn vẹn của quá trình tương tác.

**Máy chủ** là các dịch vụ cung cấp ngữ cảnh và khả năng. Chúng:

- Đăng ký các tính năng có sẵn (tài nguyên, lời nhắc, công cụ)
- Nhận và thực thi các cuộc gọi công cụ từ khách hàng
- Cung cấp thông tin ngữ cảnh để nâng cao phản hồi của mô hình
- Trả kết quả về cho khách hàng
- Duy trì trạng thái qua các tương tác khi cần thiết

Máy chủ có thể được phát triển bởi bất kỳ ai để mở rộng khả năng của mô hình với các chức năng chuyên biệt.

### 4. Các Tính Năng của Máy chủ

Máy chủ trong Giao Thức Ngữ Cảnh Mô Hình (MCP) cung cấp các khối xây dựng cơ bản cho phép tương tác phong phú giữa khách hàng, máy chủ, và các mô hình ngôn ngữ. Các tính năng này được thiết kế để nâng cao khả năng của MCP bằng cách cung cấp ngữ cảnh có cấu trúc, công cụ, và lời nhắc.

Máy chủ MCP có thể cung cấp bất kỳ tính năng nào sau đây:

#### 📑 Tài Nguyên

Tài nguyên trong Giao Thức Ngữ Cảnh Mô Hình (MCP) bao gồm các loại ngữ cảnh và dữ liệu khác nhau có thể được người dùng hoặc mô hình AI sử dụng. Chúng bao gồm:

- **Dữ Liệu Ngữ Cảnh**: Thông tin và ngữ cảnh mà người dùng hoặc mô hình AI có thể tận dụng để đưa ra quyết định và thực hiện nhiệm vụ.
- **Cơ Sở Kiến Thức và Kho Tài Liệu**: Các bộ sưu tập dữ liệu có cấu trúc và không cấu trúc, chẳng hạn như bài viết, hướng dẫn, và tài liệu nghiên cứu, cung cấp thông tin và cái nhìn sâu sắc có giá trị.
- **Tệp Cục Bộ và Cơ Sở Dữ Liệu**: Dữ liệu được lưu trữ cục bộ trên các thiết bị hoặc trong các cơ sở dữ liệu, có thể truy cập để xử lý và phân tích.
- **API và Dịch Vụ Web**: Các giao diện và dịch vụ bên ngoài cung cấp dữ liệu và chức năng bổ sung, cho phép tích hợp với các nguồn tài nguyên và công cụ trực tuyến khác nhau.

Một ví dụ về tài nguyên có thể là một sơ đồ cơ sở dữ liệu hoặc một tệp có thể được truy cập như sau:

```text
file://log.txt
database://schema
```

### 🤖 Lời Nhắc
Lời nhắc trong Giao Thức Ngữ Cảnh Mô Hình (MCP) bao gồm các mẫu và mô hình tương tác được định sẵn được thiết kế để hợp lý hóa quy trình làm việc của người dùng và nâng cao giao tiếp. Chúng bao gồm:

- **Tin Nhắn và Quy Trình Mẫu**: Các tin nhắn và quy trình có cấu trúc trước hướng dẫn người dùng thông qua các nhiệm vụ và tương tác cụ thể.
- **Mô Hình Tương Tác Định Sẵn**: Các chuỗi hành động và phản hồi tiêu chuẩn hóa tạo điều kiện cho giao tiếp nhất quán và hiệu quả.
- **Mẫu Hội Thoại Chuyên Biệt**: Các mẫu có thể tùy chỉnh được thiết kế cho các loại hội thoại cụ thể, đảm bảo tương tác phù hợp và có ngữ cảnh.

Một mẫu lời nhắc có thể trông như sau:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Công Cụ

Công cụ trong Giao Thức Ngữ Cảnh Mô Hình (MCP) là các chức năng mà mô hình AI có thể thực hiện để thực hiện các nhiệm vụ cụ thể. Các công cụ này được thiết kế để nâng cao khả năng của mô hình AI bằng cách cung cấp các hoạt động có cấu trúc và đáng tin cậy. Các khía cạnh chính bao gồm:

- **Chức Năng cho Mô Hình AI Thực Hiện**: Công cụ là các chức năng có thể thực thi mà mô hình AI có thể gọi để thực hiện các nhiệm vụ khác nhau.
- **Tên và Mô Tả Độc Đáo**: Mỗi công cụ có một tên riêng biệt và một mô tả chi tiết giải thích mục đích và chức năng của nó.
- **Tham Số và Kết Quả**: Công cụ chấp nhận các tham số cụ thể và trả về các kết quả có cấu trúc, đảm bảo kết quả nhất quán và có thể dự đoán được.
- **Chức Năng Riêng Lẻ**: Công cụ thực hiện các chức năng riêng lẻ như tìm kiếm web, tính toán, và truy vấn cơ sở dữ liệu.

Một công cụ ví dụ có thể trông như sau:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Tính Năng của Khách hàng
Trong Giao Thức Ngữ Cảnh Mô Hình (MCP), khách hàng cung cấp một số tính năng chính cho các máy chủ, nâng cao chức năng và tương tác tổng thể trong giao thức. Một trong những tính năng đáng chú ý là Lấy mẫu.

### 👉 Lấy Mẫu

- **Hành Vi Tác Nhân Khởi Tạo Từ Máy chủ**: Khách hàng cho phép máy chủ khởi tạo các hành động hoặc hành vi cụ thể một cách tự động, nâng cao khả năng động của hệ thống.
- **Tương Tác LLM Đệ Quy**: Tính năng này cho phép tương tác đệ quy với các mô hình ngôn ngữ lớn (LLM), cho phép xử lý nhiệm vụ phức tạp và lặp đi lặp lại hơn.
- **Yêu Cầu Bổ Sung Hoàn Thành Mô Hình**: Máy chủ có thể yêu cầu bổ sung các hoàn thành từ mô hình, đảm bảo rằng các phản hồi là đầy đủ và có ngữ cảnh.

## Lưu Lượng Thông Tin trong MCP

Giao Thức Ngữ Cảnh Mô Hình (MCP) định nghĩa một luồng thông tin có cấu trúc giữa các máy chủ, khách hàng, máy chủ, và mô hình. Hiểu được luồng này giúp làm rõ cách mà các yêu cầu của người dùng được xử lý và cách mà các công cụ và dữ liệu bên ngoài được tích hợp vào các phản hồi của mô hình.

- **Máy chủ Khởi Tạo Kết Nối**  
  Ứng dụng máy chủ (chẳng hạn như một IDE hoặc giao diện trò chuyện) thiết lập một kết nối đến một máy chủ MCP, thường thông qua STDIO, WebSocket, hoặc một giao thức truyền tải được hỗ trợ khác.

- **Đàm Phán Khả Năng**  
  Khách hàng (được nhúng trong máy chủ) và máy chủ trao đổi thông tin về các tính năng, công cụ, tài nguyên, và phiên bản giao thức mà họ hỗ trợ. Điều này đảm bảo cả hai bên hiểu những khả năng nào có sẵn cho phiên làm việc.

- **Yêu Cầu của Người Dùng**  
  Người dùng tương tác với máy chủ (ví dụ: nhập một lời nhắc hoặc lệnh). Máy chủ thu thập đầu vào này và chuyển nó cho khách hàng để xử lý.

- **Sử Dụng Tài Nguyên hoặc Công Cụ**  
  - Khách hàng có thể yêu cầu thêm ngữ cảnh hoặc tài nguyên từ máy chủ (chẳng hạn như tệp, mục nhập cơ sở dữ liệu, hoặc bài viết trong cơ sở kiến thức) để làm giàu sự hiểu biết của mô hình.
  - Nếu mô hình xác định rằng cần một công cụ (ví dụ: để lấy dữ liệu, thực hiện tính toán, hoặc gọi một API), khách hàng gửi một yêu cầu thực thi công cụ đến máy chủ, chỉ định tên công cụ và các tham số.

- **Thực Thi Máy chủ**  
  Máy chủ nhận yêu cầu tài nguyên hoặc công cụ, thực hiện các hoạt động cần thiết (chẳng hạn như chạy một chức năng, truy vấn một cơ sở dữ liệu, hoặc truy xuất một tệp), và trả về kết quả cho khách hàng dưới dạng có cấu trúc.

- **Tạo Phản Hồi**  
  Khách hàng tích hợp các phản hồi của máy chủ (dữ liệu tài nguyên, kết quả công cụ, v.v.) vào tương tác mô hình đang diễn ra. Mô hình sử dụng thông tin này để tạo ra một phản hồi toàn diện và có ngữ cảnh.

- **Trình Bày Kết Quả**  
  Máy chủ nhận đầu ra cuối cùng từ khách hàng và trình bày nó cho người dùng, thường bao gồm cả văn bản được tạo bởi mô hình và bất kỳ kết quả nào từ việc thực thi công cụ hoặc tìm kiếm tài nguyên.

Luồng này cho phép MCP hỗ trợ các ứng dụng AI tiên tiến, tương tác, và nhận thức ngữ cảnh bằng cách kết nối liền mạch các mô hình với các công cụ và nguồn dữ liệu bên ngoài.

## Chi Tiết Giao Thức

MCP (Giao Thức Ngữ Cảnh Mô Hình) được xây dựng trên [JSON-RPC 2.0](https://www.jsonrpc.org/), cung cấp một định dạng thông điệp chuẩn hóa, không phụ thuộc ngôn ngữ cho giao tiếp giữa các máy chủ, khách hàng, và máy chủ. Nền tảng này cho phép các tương tác đáng tin cậy, có cấu trúc, và mở rộng trên các nền tảng và ngôn ngữ lập trình khác nhau.

### Các Tính Năng Chính của Giao Thức

MCP mở rộng JSON-RPC 2.0 với các quy ước bổ sung cho việc thực thi công cụ, truy cập tài nguyên, và quản lý lời nhắc. Nó hỗ trợ nhiều lớp truyền tải (STDIO, WebSocket, SSE) và cho phép giao tiếp an toàn, mở rộng, và không phụ thuộc ngôn ngữ giữa các thành phần.

#### 🧢 Giao Thức Cơ Bản

- **Định Dạng Thông Điệp JSON-RPC**: Tất cả các yêu cầu và phản hồi sử dụng đặc tả JSON-RPC 2.0, đảm bảo cấu trúc nhất quán cho các cuộc gọi phương thức, tham số, kết quả, và xử lý lỗi.
- **Kết Nối Có Trạng Thái**: Các phiên MCP duy trì trạng thái qua nhiều yêu cầu, hỗ trợ các cuộc hội thoại đang diễn ra, tích lũy ngữ cảnh, và quản lý tài nguyên.
- **Đàm Phán Khả Năng**: Trong quá trình thiết lập kết nối, khách hàng và máy chủ trao đổi thông tin về các tính năng được hỗ trợ, phiên bản giao thức, các công cụ có sẵn, và tài nguyên. Điều này đảm bảo cả hai bên hiểu khả năng của nhau và có thể điều chỉnh cho phù hợp.

#### ➕ Tiện Ích Bổ Sung

Dưới đây là một số tiện ích bổ sung và mở rộng giao thức mà MCP cung cấp để nâng cao trải nghiệm của nhà phát triển và cho phép các kịch bản tiên tiến:

- **Tùy Chọn Cấu Hình**: MCP cho phép cấu hình động các tham số phiên, chẳng hạn như quyền công cụ, truy cập tài nguyên, và cài đặt mô hình, được điều chỉnh cho từng tương tác.
- **Theo Dõi Tiến Độ**: Các hoạt động kéo dài có thể báo cáo các cập nhật tiến độ, cho phép giao diện người dùng đáp ứng và cải thiện trải nghiệm người dùng trong các nhiệm vụ phức tạp.
- **Hủy Yêu Cầu**: Khách hàng có thể hủy các yêu cầu đang bay, cho phép người dùng ngắt các hoạt động không còn cần thiết hoặc mất quá nhiều thời gian.
- **Báo Cáo Lỗi**: Các thông điệp và mã lỗi chuẩn hóa giúp chẩn đoán các vấn đề, xử lý lỗi một cách tinh tế, và cung cấp phản hồi có thể hành động cho người dùng và nhà phát triển.
- **Ghi Nhật Ký**: Cả khách hàng và máy chủ có thể phát ra các nhật ký có cấu trúc để kiểm toán, gỡ lỗi, và giám sát các tương tác giao thức.

Bằng cách tận dụng các tính năng giao thức này, MCP đảm bảo giao tiếp mạnh mẽ, an toàn, và linh hoạt giữa các mô hình ngôn ngữ và các công cụ hoặc nguồn dữ liệu bên ngoài.

### 🔐 Các Cân Nhắc về Bảo Mật

Các triển khai MCP nên tuân thủ một số nguyên tắc bảo mật chính để đảm bảo các tương tác an toàn và đáng tin cậy:

- **Sự Đồng Ý và Kiểm Soát của Người Dùng**: Người dùng phải cung cấp sự đồng ý rõ ràng trước khi bất kỳ dữ liệu nào được truy cập hoặc các hoạt động được thực hiện. Họ nên có quyền kiểm soát rõ ràng về dữ liệu nào được chia sẻ và các hành động nào được ủy quyền, được hỗ trợ bởi giao diện người dùng trực quan để xem xét và phê duyệt các hoạt động.

- **Bảo Mật Dữ Liệu**: Dữ liệu người dùng chỉ nên được tiếp xúc với sự đồng ý rõ ràng và phải được bảo vệ bởi các kiểm soát truy cập thích hợp. Các triển khai MCP phải bảo vệ chống lại việc truyền dữ liệu trái phép và đảm bảo rằng quyền riêng tư được duy trì trong suốt tất cả các tương tác.

- **An Toàn Công Cụ**: Trước khi thực thi bất kỳ công cụ nào, cần có sự đồng ý rõ ràng của người dùng. Người dùng nên có sự hiểu biết rõ ràng về chức năng của từng công cụ, và các ranh giới bảo mật mạnh mẽ phải được thực thi để ngăn chặn việc thực thi công cụ không mong muốn hoặc không an toàn.

Bằng cách tuân theo các nguyên tắc này, MCP đảm bảo rằng niềm tin, quyền riêng tư, và an toàn của người dùng được duy trì trong tất cả các tương tác giao thức.

## Ví Dụ Mã: Các Thành Phần Chính

Dưới đây là các ví dụ mã trong một số ngôn ngữ lập trình phổ biến minh họa cách triển khai các thành phần máy chủ MCP chính và các công cụ.

### Ví Dụ .NET: Tạo Máy chủ MCP Đơn Giản với Công Cụ

Dưới đây là một ví dụ mã .NET thực tế minh họa cách triển khai một máy chủ MCP đơn giản với các công cụ tùy chỉnh. Ví dụ này trình bày cách định nghĩa và đăng ký công cụ, xử lý yêu cầu, và kết nối máy chủ bằng Giao Thức Ngữ Cảnh Mô Hình.

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

### Ví Dụ Java: Các Thành Phần Máy chủ MCP

Ví

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa của nó nên được coi là nguồn đáng tin cậy. Đối với thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.