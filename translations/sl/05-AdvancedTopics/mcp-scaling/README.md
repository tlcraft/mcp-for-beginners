<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:59:01+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "sl"
}
-->
## Porazdeljena arhitektura

Porazdeljene arhitekture vključujejo več MCP vozlišč, ki sodelujejo pri obdelavi zahtevkov, delitvi virov in zagotavljanju redundance. Ta pristop izboljša skalabilnost in odpornost na napake, saj vozlišča med seboj komunicirajo in se usklajujejo preko porazdeljenega sistema.

Poglejmo primer, kako uvesti porazdeljeno MCP strežniško arhitekturo z uporabo Redis za koordinacijo.

## Kaj sledi

- [Varnost](../mcp-security/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazumevanja ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.