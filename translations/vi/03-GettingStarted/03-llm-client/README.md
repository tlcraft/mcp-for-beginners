<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:24:47+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "vi"
}
-->
# Tạo một client với LLM

Cho đến nay, bạn đã thấy cách tạo một server và một client. Client có thể gọi server một cách rõ ràng để liệt kê các công cụ, tài nguyên và prompts của nó. Tuy nhiên, đây không phải là một cách tiếp cận thực tế. Người dùng của bạn đang sống trong thời đại agentic và mong đợi sử dụng prompts và giao tiếp với một LLM để làm điều đó. Đối với người dùng của bạn, họ không quan tâm nếu bạn sử dụng MCP hay không để lưu trữ khả năng của mình, nhưng họ mong muốn sử dụng ngôn ngữ tự nhiên để tương tác. Vậy làm thế nào để chúng ta giải quyết vấn đề này? Giải pháp là thêm một LLM vào client.

## Tổng quan

Trong bài học này, chúng ta tập trung vào việc thêm một LLM vào client của bạn và cho thấy cách này cung cấp trải nghiệm tốt hơn nhiều cho người dùng của bạn.

## Mục tiêu học tập

Đến cuối bài học này, bạn sẽ có thể:

- Tạo một client với một LLM.
- Tương tác liền mạch với một server MCP bằng cách sử dụng một LLM.
- Cung cấp trải nghiệm người dùng tốt hơn từ phía client.

## Cách tiếp cận

Hãy thử hiểu cách tiếp cận mà chúng ta cần thực hiện. Thêm một LLM nghe có vẻ đơn giản, nhưng chúng ta thực sự sẽ làm điều này như thế nào?

Đây là cách client sẽ tương tác với server:

1. Thiết lập kết nối với server.

1. Liệt kê các khả năng, prompts, tài nguyên và công cụ, và lưu lại schema của chúng.

1. Thêm một LLM và truyền các khả năng đã lưu và schema của chúng ở định dạng mà LLM hiểu.

1. Xử lý một prompt của người dùng bằng cách truyền nó cho LLM cùng với các công cụ được client liệt kê.

Tuyệt vời, bây giờ chúng ta hiểu cách thực hiện điều này ở mức độ cao, hãy thử thực hiện trong bài tập dưới đây.

## Bài tập: Tạo một client với một LLM

Trong bài tập này, chúng ta sẽ học cách thêm một LLM vào client của chúng ta.

### -1- Kết nối với server

Hãy tạo client của chúng ta trước:
Bạn được đào tạo trên dữ liệu đến tháng 10 năm 2023.

Tuyệt vời, cho bước tiếp theo, hãy liệt kê các khả năng trên server.

### -2 Liệt kê khả năng của server

Bây giờ chúng ta sẽ kết nối với server và yêu cầu các khả năng của nó:

### -3- Chuyển đổi khả năng của server thành công cụ của LLM

Bước tiếp theo sau khi liệt kê khả năng của server là chuyển đổi chúng thành định dạng mà LLM hiểu. Khi chúng ta làm điều đó, chúng ta có thể cung cấp những khả năng này như là công cụ cho LLM của chúng ta.

Tuyệt vời, chúng ta chưa được thiết lập để xử lý bất kỳ yêu cầu nào của người dùng, vì vậy hãy giải quyết điều đó tiếp theo.

### -4- Xử lý yêu cầu prompt của người dùng

Trong phần này của mã, chúng ta sẽ xử lý các yêu cầu của người dùng.

Tuyệt vời, bạn đã làm được!

## Bài tập

Lấy mã từ bài tập và xây dựng server với một số công cụ khác. Sau đó tạo một client với một LLM, như trong bài tập, và thử nghiệm với các prompts khác nhau để đảm bảo tất cả các công cụ server của bạn được gọi một cách linh hoạt. Cách xây dựng client này có nghĩa là người dùng cuối sẽ có trải nghiệm tuyệt vời vì họ có thể sử dụng prompts, thay vì các lệnh client chính xác, và không cần biết về bất kỳ server MCP nào được gọi.

## Giải pháp

[Giải pháp](/03-GettingStarted/03-llm-client/solution/README.md)

## Những điểm chính

- Thêm một LLM vào client của bạn cung cấp một cách tốt hơn cho người dùng tương tác với các server MCP.
- Bạn cần chuyển đổi phản hồi của server MCP thành một thứ mà LLM có thể hiểu.

## Mẫu

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

## Tiếp theo là gì

- Tiếp theo: [Tiêu thụ một server bằng Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa của nó nên được coi là nguồn đáng tin cậy. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.