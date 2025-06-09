<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:57:52+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "cs"
}
-->
## Vertikální škálování a optimalizace zdrojů

Vertikální škálování se zaměřuje na optimalizaci jednoho instance MCP serveru tak, aby efektivně zvládal více požadavků. Toho lze dosáhnout laděním konfigurací, použitím efektivních algoritmů a efektivním řízením zdrojů. Například můžete upravit thread pooly, časové limity požadavků a limity paměti pro zlepšení výkonu.

Podívejme se na příklad, jak optimalizovat MCP server pro vertikální škálování a správu zdrojů.

## Distribuovaná architektura

Distribuované architektury zahrnují více MCP uzlů, které spolupracují na zpracování požadavků, sdílení zdrojů a poskytování redundance. Tento přístup zvyšuje škálovatelnost a odolnost vůči chybám tím, že umožňuje uzlům komunikovat a koordinovat se prostřednictvím distribuovaného systému.

Podívejme se na příklad, jak implementovat distribuovanou architekturu MCP serveru s využitím Redis pro koordinaci.

## Co bude dál

- [Security](../mcp-security/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.