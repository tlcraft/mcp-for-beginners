<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T07:44:19+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "vi"
}
-->
# SSE Server

SSE (Server Sent Events) là một chuẩn để truyền dữ liệu từ server đến client theo dạng streaming, cho phép server đẩy các cập nhật thời gian thực đến client qua HTTP. Điều này đặc biệt hữu ích cho các ứng dụng cần cập nhật trực tiếp, như ứng dụng chat, thông báo, hoặc các nguồn dữ liệu thời gian thực. Ngoài ra, server của bạn có thể được nhiều client sử dụng cùng lúc vì nó chạy trên một server có thể đặt ở bất kỳ đâu, ví dụ như trên đám mây.

## Tổng quan

Bài học này sẽ hướng dẫn cách xây dựng và sử dụng SSE Server.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:

- Xây dựng một SSE Server.
- Gỡ lỗi SSE Server bằng Inspector.
- Sử dụng SSE Server với Visual Studio Code.

## SSE, cách hoạt động

SSE là một trong hai loại transport được hỗ trợ. Bạn đã từng thấy loại đầu tiên là stdio được sử dụng trong các bài học trước. Sự khác biệt như sau:

- SSE yêu cầu bạn xử lý hai việc: kết nối và tin nhắn.
- Vì đây là một server có thể chạy ở bất kỳ đâu, bạn cần điều chỉnh cách làm việc với các công cụ như Inspector và Visual Studio Code sao cho phù hợp. Điều này có nghĩa là thay vì chỉ cách khởi động server, bạn sẽ chỉ đến endpoint nơi có thể thiết lập kết nối. Xem ví dụ mã dưới đây:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

Trong đoạn mã trên:

- `/sse` được thiết lập làm route. Khi có yêu cầu đến route này, một instance transport mới được tạo và server *kết nối* qua transport này.
- `/messages` là route xử lý các tin nhắn đến.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

Trong đoạn mã trên:

- Tạo một instance server ASGI (cụ thể dùng Starlette) và gắn route mặc định `/`.

  Ở phía sau, các route `/sse` và `/messages` được thiết lập để xử lý kết nối và tin nhắn tương ứng. Phần còn lại của ứng dụng, như thêm các tính năng, công cụ, vẫn hoạt động như với server stdio.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Có hai phương thức giúp chuyển từ web server sang web server hỗ trợ SSE:

    - `AddMcpServer`, phương thức này thêm các khả năng.
    - `MapMcp`, phương thức này thêm các route như `/SSE` và `/messages`.

Bây giờ khi đã hiểu thêm về SSE, hãy cùng xây dựng một SSE server.

## Bài tập: Tạo SSE Server

Để tạo server, cần lưu ý hai điều:

- Cần dùng web server để mở các endpoint cho kết nối và tin nhắn.
- Xây dựng server như bình thường với các công cụ, tài nguyên và prompt khi dùng stdio.

### -1- Tạo instance server

Để tạo server, ta dùng cùng loại như với stdio. Tuy nhiên, với transport, ta chọn SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

Trong đoạn mã trên, ta đã:

- Tạo một instance server.
- Định nghĩa app sử dụng framework web express.
- Tạo biến transports để lưu các kết nối đến.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Trong đoạn mã trên, ta đã:

- Import các thư viện cần thiết, trong đó có Starlette (một framework ASGI).
- Tạo instance MCP server `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Ở bước này, ta đã:

- Tạo ứng dụng web.
- Thêm hỗ trợ cho các tính năng MCP qua `AddMcpServer`.

Tiếp theo, ta sẽ thêm các route cần thiết.

### -2- Thêm các route

Tiếp theo, ta thêm các route xử lý kết nối và tin nhắn đến:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

Trong đoạn mã trên, ta đã định nghĩa:

- Route `/sse` tạo một transport kiểu SSE và gọi `connect` trên MCP server.
- Route `/messages` xử lý các tin nhắn đến.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Trong đoạn mã trên, ta đã:

- Tạo instance app ASGI dùng framework Starlette. Trong đó, ta truyền `mcp.sse_app()` vào danh sách route, từ đó gắn các route `/sse` và `/messages` lên app.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Ta đã thêm dòng `add.MapMcp()` ở cuối, nghĩa là giờ đã có các route `/SSE` và `/messages`.

Tiếp theo, ta sẽ thêm các khả năng cho server.

### -3- Thêm khả năng cho server

Khi đã định nghĩa xong các phần riêng của SSE, ta thêm các khả năng như công cụ, prompt và tài nguyên.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

Ví dụ cách thêm một công cụ. Công cụ này tạo một tool gọi là "random-joke" dùng API của Chuck Norris và trả về kết quả JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Giờ server của bạn đã có một công cụ.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Trước tiên, tạo một số công cụ, ta sẽ tạo file *Tools.cs* với nội dung sau:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Ở đây ta đã:

  - Tạo lớp `Tools` với decorator `McpServerToolType`.
  - Định nghĩa công cụ `AddNumbers` bằng cách trang trí phương thức với `McpServerTool`. Đồng thời cung cấp tham số và phần cài đặt.

1. Sử dụng lớp `Tools` vừa tạo:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Ta đã thêm gọi `WithTools` chỉ định `Tools` là lớp chứa các công cụ. Vậy là xong, ta đã sẵn sàng.

Tuyệt vời, ta đã có server dùng SSE, giờ hãy thử chạy nó.

## Bài tập: Gỡ lỗi SSE Server với Inspector

Inspector là công cụ rất hữu ích mà ta đã thấy trong bài học trước [Creating your first server](/03-GettingStarted/01-first-server/README.md). Hãy xem ta có thể dùng Inspector ở đây không:

### -1- Chạy inspector

Để chạy inspector, trước tiên bạn phải có server SSE đang chạy, vậy ta làm như sau:

1. Chạy server

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Lưu ý ta dùng executable `uvicorn` được cài khi gõ `pip install "mcp[cli]"`. Việc gõ `server:app` nghĩa là ta chạy file `server.py` và trong đó có instance Starlette tên `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Lệnh này sẽ khởi động server. Để tương tác với nó, bạn cần mở một terminal mới.

1. Chạy inspector

    > ![NOTE]
    > Chạy lệnh này trong cửa sổ terminal khác với nơi server đang chạy. Lưu ý bạn cần chỉnh sửa lệnh dưới đây cho phù hợp với URL server của bạn.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Việc chạy inspector giống nhau ở tất cả runtime. Lưu ý thay vì truyền đường dẫn đến server và lệnh khởi động server, ta truyền URL server đang chạy và chỉ định route `/sse`.

### -2- Thử công cụ

Kết nối server bằng cách chọn SSE trong danh sách thả xuống và điền URL server đang chạy, ví dụ http:localhost:4321/sse. Bấm nút "Connect". Như trước, chọn list tools, chọn một công cụ và nhập giá trị đầu vào. Bạn sẽ thấy kết quả như hình dưới:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.vi.png)

Tuyệt vời, bạn đã có thể làm việc với inspector, giờ hãy xem cách làm việc với Visual Studio Code.

## Bài tập

Hãy thử mở rộng server với nhiều khả năng hơn. Tham khảo [trang này](https://api.chucknorris.io/) để, ví dụ, thêm công cụ gọi API. Bạn quyết định server sẽ như thế nào. Chúc vui :)

## Giải pháp

[Giải pháp](./solution/README.md) Đây là một giải pháp có mã hoạt động.

## Những điểm chính cần nhớ

Những điểm chính trong chương này là:

- SSE là loại transport thứ hai được hỗ trợ bên cạnh stdio.
- Để hỗ trợ SSE, bạn cần quản lý kết nối và tin nhắn đến bằng framework web.
- Bạn có thể dùng cả Inspector và Visual Studio Code để sử dụng SSE server, giống như với stdio server. Lưu ý có một số khác biệt nhỏ giữa stdio và SSE. Với SSE, bạn cần khởi động server riêng rồi mới chạy công cụ inspector. Với inspector, bạn cũng cần chỉ định URL server.

## Mẫu ví dụ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Tài nguyên bổ sung

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Tiếp theo

- Tiếp theo: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.