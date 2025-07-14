<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-07-14T02:33:48+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "sl"
}
-->
## Porazdeljena arhitektura

Porazdeljene arhitekture vključujejo več MCP vozlišč, ki sodelujejo pri obdelavi zahtevkov, delitvi virov in zagotavljanju redundance. Ta pristop izboljšuje razširljivost in odpornost na napake, saj vozlišča med seboj komunicirajo in se usklajujejo preko porazdeljenega sistema.

Poglejmo primer, kako implementirati porazdeljeno arhitekturo MCP strežnika z uporabo Redis za koordinacijo.

## Kaj sledi

- [5.8 Varnost](../mcp-security/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.