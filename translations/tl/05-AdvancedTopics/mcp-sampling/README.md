<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3cb0da3badd51d73ab78ebade2827d98",
  "translation_date": "2025-06-13T00:42:07+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "tl"
}
-->
## Deterministic Sampling

Para sa mga aplikasyon na nangangailangan ng pare-parehong output, ang deterministic sampling ay nagsisiguro ng mga resulta na maaaring ulitin. Ginagawa ito sa pamamagitan ng paggamit ng fixed random seed at pagtatakda ng temperature sa zero.

Tingnan natin ang mga halimbawa ng implementasyon para ipakita ang deterministic sampling sa iba't ibang programming languages.

## Dynamic Sampling Configuration

Ang intelligent sampling ay inaangkop ang mga parameter base sa konteksto at pangangailangan ng bawat request. Ibig sabihin, dynamic na ina-adjust ang mga parameter tulad ng temperature, top_p, at penalties base sa uri ng gawain, kagustuhan ng user, o nakaraang performance.

Tingnan natin kung paano i-implement ang dynamic sampling sa iba't ibang programming languages.

## What's next

- [5.7 Scaling](../mcp-scaling/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na pangunahing sanggunian. Para sa mga mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.