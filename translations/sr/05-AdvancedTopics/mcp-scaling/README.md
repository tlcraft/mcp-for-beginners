<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:58:39+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "sr"
}
-->
## Distribuirana arhitektura

Distribuirane arhitekture uključuju više MCP čvorova koji rade zajedno kako bi obrađivali zahteve, delili resurse i obezbedili redundantnost. Ovaj pristup poboljšava skalabilnost i otpornost na greške omogućavajući čvorovima da komuniciraju i koordiniraju se kroz distribuirani sistem.

Pogledajmo primer kako implementirati distribuiranu MCP arhitekturu koristeći Redis za koordinaciju.

## Šta sledi

- [Bezbednost](../mcp-security/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI servisa za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja nastala korišćenjem ovog prevoda.