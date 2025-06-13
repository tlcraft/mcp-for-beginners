<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T01:22:55+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "hr"
}
-->
## Vertikalno skaliranje i optimizacija resursa

Vertikalno skaliranje usredotočeno je na optimizaciju jedne instance MCP servera kako bi učinkovitije obrađivala više zahtjeva. To se može postići finim podešavanjem konfiguracija, korištenjem učinkovitih algoritama i učinkovitim upravljanjem resursima. Na primjer, možete prilagoditi thread pool-ove, timeout-e za zahtjeve i ograničenja memorije kako biste poboljšali performanse.

Pogledajmo primjer kako optimizirati MCP server za vertikalno skaliranje i upravljanje resursima.

## Distribuirana arhitektura

Distribuirane arhitekture uključuju više MCP čvorova koji zajedno rade na obradi zahtjeva, dijele resurse i pružaju redundanciju. Ovaj pristup poboljšava skalabilnost i otpornost na greške omogućujući čvorovima da komuniciraju i koordiniraju se kroz distribuirani sustav.

Pogledajmo primjer kako implementirati distribuiranu arhitekturu MCP servera koristeći Redis za koordinaciju.

## Što slijedi

- [5.8 Security](../mcp-security/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.