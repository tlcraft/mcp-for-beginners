<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:10:34+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "id"
}
-->
## Pengujian dan Debugging

Sebelum Anda mulai menguji server MCP Anda, penting untuk memahami alat yang tersedia dan praktik terbaik untuk debugging. Pengujian yang efektif memastikan server Anda berperilaku sesuai harapan dan membantu Anda dengan cepat mengidentifikasi serta menyelesaikan masalah. Bagian berikut menguraikan pendekatan yang direkomendasikan untuk memvalidasi implementasi MCP Anda.

## Gambaran Umum

Pelajaran ini membahas cara memilih pendekatan pengujian yang tepat dan alat pengujian yang paling efektif.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Menjelaskan berbagai pendekatan untuk pengujian.
- Menggunakan berbagai alat untuk menguji kode Anda secara efektif.

## Pengujian Server MCP

MCP menyediakan alat untuk membantu Anda menguji dan melakukan debugging server Anda:

- **MCP Inspector**: Alat baris perintah yang dapat dijalankan baik sebagai alat CLI maupun alat visual.
- **Pengujian manual**: Anda dapat menggunakan alat seperti curl untuk menjalankan permintaan web, tetapi alat apa pun yang mampu menjalankan HTTP juga bisa digunakan.
- **Unit testing**: Anda dapat menggunakan framework pengujian pilihan Anda untuk menguji fitur dari server maupun klien.

### Menggunakan MCP Inspector

Kami telah menjelaskan penggunaan alat ini dalam pelajaran sebelumnya, tetapi mari kita bahas sedikit secara garis besar. Ini adalah alat yang dibangun dengan Node.js dan Anda dapat menggunakannya dengan memanggil executable `npx` yang akan mengunduh dan menginstal alat tersebut secara sementara dan membersihkan dirinya sendiri setelah selesai menjalankan permintaan Anda.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) membantu Anda:

- **Menemukan Kapabilitas Server**: Secara otomatis mendeteksi sumber daya, alat, dan prompt yang tersedia
- **Menguji Eksekusi Alat**: Mencoba parameter berbeda dan melihat respons secara real-time
- **Melihat Metadata Server**: Memeriksa info server, skema, dan konfigurasi

Contoh menjalankan alat ini seperti berikut:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Perintah di atas memulai MCP dan antarmuka visualnya serta meluncurkan antarmuka web lokal di browser Anda. Anda dapat melihat dashboard yang menampilkan server MCP yang terdaftar, alat yang tersedia, sumber daya, dan prompt mereka. Antarmuka ini memungkinkan Anda untuk menguji eksekusi alat secara interaktif, memeriksa metadata server, dan melihat respons secara real-time, sehingga memudahkan validasi dan debugging implementasi server MCP Anda.

Ini tampilannya: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.id.png)

Anda juga dapat menjalankan alat ini dalam mode CLI dengan menambahkan atribut `--cli`. Berikut contoh menjalankan alat dalam mode "CLI" yang menampilkan semua alat di server:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Pengujian Manual

Selain menjalankan alat inspector untuk menguji kapabilitas server, pendekatan serupa adalah menjalankan klien yang mampu menggunakan HTTP seperti misalnya curl.

Dengan curl, Anda dapat menguji server MCP secara langsung menggunakan permintaan HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Seperti yang Anda lihat dari penggunaan curl di atas, Anda menggunakan permintaan POST untuk memanggil alat menggunakan payload yang terdiri dari nama alat dan parameternya. Gunakan pendekatan yang paling sesuai untuk Anda. Alat CLI umumnya lebih cepat digunakan dan mudah untuk dibuat skrip, yang bisa berguna dalam lingkungan CI/CD.

### Unit Testing

Buat unit test untuk alat dan sumber daya Anda untuk memastikan mereka bekerja sesuai harapan. Berikut contoh kode pengujian.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Kode di atas melakukan hal berikut:

- Memanfaatkan framework pytest yang memungkinkan Anda membuat tes sebagai fungsi dan menggunakan pernyataan assert.
- Membuat MCP Server dengan dua alat yang berbeda.
- Menggunakan pernyataan `assert` untuk memeriksa bahwa kondisi tertentu terpenuhi.

Lihat [file lengkap di sini](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Dengan file di atas, Anda dapat menguji server Anda sendiri untuk memastikan kapabilitas dibuat sesuai yang diharapkan.

Semua SDK utama memiliki bagian pengujian serupa sehingga Anda dapat menyesuaikan dengan runtime pilihan Anda.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Selanjutnya

- Selanjutnya: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.