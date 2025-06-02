<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:58:49+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "hr"
}
-->
## Vertikalno skaliranje i optimizacija resursa

Vertikalno skaliranje usredotočuje se na optimizaciju jedne MCP poslužiteljske instance kako bi učinkovito obrađivala više zahtjeva. To se može postići podešavanjem konfiguracija, korištenjem učinkovitih algoritama i učinkovitim upravljanjem resursima. Na primjer, možete prilagoditi thread poolove, vremenska ograničenja zahtjeva i memorijske limite za poboljšanje performansi.

Pogledajmo primjer kako optimizirati MCP poslužitelj za vertikalno skaliranje i upravljanje resursima.

## Distribuirana arhitektura

Distribuirane arhitekture uključuju više MCP čvorova koji rade zajedno kako bi obrađivali zahtjeve, dijelili resurse i osiguravali redundantnost. Ovaj pristup povećava skalabilnost i otpornost na pogreške dopuštajući čvorovima da komuniciraju i koordiniraju se kroz distribuirani sustav.

Pogledajmo primjer kako implementirati distribuiranu MCP poslužiteljsku arhitekturu koristeći Redis za koordinaciju.

## Što slijedi

- [Security](../mcp-security/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.