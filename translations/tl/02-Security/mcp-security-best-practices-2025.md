<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:54:52+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "tl"
}
-->
# MCP Security Best Practices - Hulyo 2025 Update

## Komprehensibong Mga Pinakamahusay na Praktis sa Seguridad para sa Mga Implementasyon ng MCP

Kapag nagtatrabaho sa mga MCP server, sundin ang mga pinakamahusay na praktis sa seguridad na ito upang maprotektahan ang iyong data, imprastruktura, at mga gumagamit:

1. **Input Validation**: Laging i-validate at linisin ang mga input upang maiwasan ang injection attacks at confused deputy problems.
   - Magpatupad ng mahigpit na validation para sa lahat ng tool parameters
   - Gumamit ng schema validation upang matiyak na ang mga kahilingan ay sumusunod sa inaasahang mga format
   - Salain ang mga posibleng mapanganib na nilalaman bago iproseso

2. **Access Control**: Magpatupad ng tamang authentication at authorization para sa iyong MCP server na may detalyadong mga pahintulot.
   - Gumamit ng OAuth 2.0 kasama ang mga kilalang identity provider tulad ng Microsoft Entra ID
   - Magpatupad ng role-based access control (RBAC) para sa mga MCP tool
   - Huwag kailanman gumawa ng custom authentication kung may umiiral nang mga solusyon

3. **Secure Communication**: Gumamit ng HTTPS/TLS para sa lahat ng komunikasyon sa iyong MCP server at isaalang-alang ang dagdag na encryption para sa sensitibong data.
   - I-configure ang TLS 1.3 kung posible
   - Magpatupad ng certificate pinning para sa mga kritikal na koneksyon
   - Regular na palitan ang mga sertipiko at tiyaking valid ang mga ito

4. **Rate Limiting**: Magpatupad ng rate limiting upang maiwasan ang pang-aabuso, DoS attacks, at upang pamahalaan ang paggamit ng mga resources.
   - Magtakda ng angkop na limitasyon sa mga kahilingan base sa inaasahang pattern ng paggamit
   - Magpatupad ng graduated responses sa sobrang dami ng kahilingan
   - Isaalang-alang ang user-specific rate limits base sa authentication status

5. **Logging and Monitoring**: Subaybayan ang iyong MCP server para sa mga kahina-hinalang aktibidad at magpatupad ng komprehensibong audit trails.
   - I-log ang lahat ng authentication attempts at tool invocations
   - Magpatupad ng real-time alerting para sa mga kahina-hinalang pattern
   - Tiyaking ang mga log ay ligtas na nakaimbak at hindi maaaring baguhin

6. **Secure Storage**: Protektahan ang sensitibong data at mga kredensyal gamit ang tamang encryption habang nakaimbak.
   - Gumamit ng key vaults o secure credential stores para sa lahat ng mga sikreto
   - Magpatupad ng field-level encryption para sa sensitibong data
   - Regular na palitan ang mga encryption key at kredensyal

7. **Token Management**: Iwasan ang token passthrough vulnerabilities sa pamamagitan ng pag-validate at paglilinis ng lahat ng model inputs at outputs.
   - Magpatupad ng token validation base sa audience claims
   - Huwag tanggapin ang mga token na hindi tahasang inilabas para sa iyong MCP server
   - Magpatupad ng tamang token lifetime management at rotation

8. **Session Management**: Magpatupad ng secure session handling upang maiwasan ang session hijacking at fixation attacks.
   - Gumamit ng secure, non-deterministic session IDs
   - I-bind ang mga session sa user-specific na impormasyon
   - Magpatupad ng tamang session expiration at rotation

9. **Tool Execution Sandboxing**: Patakbuhin ang mga tool execution sa mga hiwalay na kapaligiran upang maiwasan ang lateral movement kung ma-kompromiso.
   - Magpatupad ng container isolation para sa tool execution
   - Maglagay ng resource limits upang maiwasan ang resource exhaustion attacks
   - Gumamit ng hiwalay na execution contexts para sa iba't ibang security domains

10. **Regular Security Audits**: Magsagawa ng pana-panahong pagsusuri sa seguridad ng iyong mga implementasyon ng MCP at mga dependencies.
    - Mag-iskedyul ng regular penetration testing
    - Gumamit ng automated scanning tools upang matukoy ang mga kahinaan
    - Panatilihing updated ang mga dependencies upang matugunan ang mga kilalang isyu sa seguridad

11. **Content Safety Filtering**: Magpatupad ng content safety filters para sa parehong inputs at outputs.
    - Gumamit ng Azure Content Safety o katulad na serbisyo upang matukoy ang mapanganib na nilalaman
    - Magpatupad ng prompt shield techniques upang maiwasan ang prompt injection
    - I-scan ang mga generated content para sa posibleng pag-leak ng sensitibong data

12. **Supply Chain Security**: Suriin ang integridad at pagiging tunay ng lahat ng bahagi sa iyong AI supply chain.
    - Gumamit ng signed packages at i-verify ang mga signature
    - Magpatupad ng software bill of materials (SBOM) analysis
    - Subaybayan ang mga malisyosong update sa mga dependencies

13. **Tool Definition Protection**: Iwasan ang tool poisoning sa pamamagitan ng pag-secure ng mga tool definitions at metadata.
    - I-validate ang mga tool definitions bago gamitin
    - Subaybayan ang mga hindi inaasahang pagbabago sa tool metadata
    - Magpatupad ng integrity checks para sa mga tool definitions

14. **Dynamic Execution Monitoring**: Subaybayan ang runtime behavior ng mga MCP server at tool.
    - Magpatupad ng behavioral analysis upang matukoy ang mga anomalya
    - Mag-set up ng alerting para sa mga hindi inaasahang execution patterns
    - Gumamit ng runtime application self-protection (RASP) techniques

15. **Principle of Least Privilege**: Tiyaking ang mga MCP server at tool ay gumagana lamang sa pinakamababang kinakailangang pahintulot.
    - Magbigay lamang ng mga partikular na pahintulot na kailangan para sa bawat operasyon
    - Regular na suriin at i-audit ang paggamit ng mga pahintulot
    - Magpatupad ng just-in-time access para sa mga administratibong function

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.