<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T01:27:27+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "sl"
}
-->
## Porazdeljena arhitektura

Porazdeljene arhitekture vključujejo več MCP vozlišč, ki sodelujejo pri obdelavi zahtevkov, deljenju virov in zagotavljanju redundantnosti. Ta pristop izboljšuje razširljivost in odpornost na napake, saj vozlišča komunicirajo in usklajujejo delovanje preko porazdeljenega sistema.

Poglejmo primer, kako implementirati porazdeljeno MCP strežniško arhitekturo z uporabo Redis za koordinacijo.

## Kaj sledi

- [5.8 Varnost](../mcp-security/README.md)

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.