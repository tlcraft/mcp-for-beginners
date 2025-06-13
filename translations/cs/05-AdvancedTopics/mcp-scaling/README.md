<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T00:58:37+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "cs"
}
-->
## Vertikální škálování a optimalizace zdrojů

Vertikální škálování se zaměřuje na optimalizaci jedné instance MCP serveru tak, aby efektivně zvládla více požadavků. Toho lze dosáhnout doladěním konfigurací, použitím efektivních algoritmů a efektivním řízením zdrojů. Například můžete upravit thread pooly, timeouty požadavků a limity paměti pro zlepšení výkonu.

Podívejme se na příklad, jak optimalizovat MCP server pro vertikální škálování a správu zdrojů.

## Distribuovaná architektura

Distribuované architektury zahrnují více MCP uzlů, které spolupracují na zpracování požadavků, sdílení zdrojů a poskytování redundance. Tento přístup zvyšuje škálovatelnost a odolnost vůči chybám tím, že umožňuje uzlům komunikovat a koordinovat se prostřednictvím distribuovaného systému.

Podívejme se na příklad, jak implementovat distribuovanou architekturu MCP serveru pomocí Redis pro koordinaci.

## Co bude dál

- [5.8 Security](../mcp-security/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.