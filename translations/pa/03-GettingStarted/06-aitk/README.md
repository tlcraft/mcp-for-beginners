<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:19:57+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "pa"
}
-->
# ਵਿਜੁਅਲ ਸਟੂਡੀਓ ਕੋਡ ਲਈ ਏਆਈ ਟੂਲਕਿਟ ਐਕਸਟੈਂਸ਼ਨ ਤੋਂ ਸਰਵਰ ਦੀ ਖਪਤ

ਜਦੋਂ ਤੁਸੀਂ ਇੱਕ ਏਆਈ ਏਜੰਟ ਬਣਾ ਰਹੇ ਹੋ, ਤਾਂ ਇਹ ਸਿਰਫ ਸਿਆਣੇ ਜਵਾਬ ਜਨਰੇਟ ਕਰਨ ਬਾਰੇ ਨਹੀਂ ਹੈ; ਇਹ ਤੁਹਾਡੇ ਏਜੰਟ ਨੂੰ ਕਾਰਵਾਈ ਕਰਨ ਦੀ ਸਮਰਥਾ ਦੇਣ ਬਾਰੇ ਵੀ ਹੈ। ਇਹਥੇ ਮਾਡਲ ਕੰਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਅਪਣਾ ਕਿਰਦਾਰ ਨਿਭਾਉਂਦਾ ਹੈ। MCP ਏਜੰਟਾਂ ਲਈ ਬਾਹਰੀ ਟੂਲ ਅਤੇ ਸੇਵਾਵਾਂ ਨੂੰ ਇੱਕ ਸੰਕਲਿਤ ਤਰੀਕੇ ਨਾਲ ਐਕਸੈਸ ਕਰਨਾ ਆਸਾਨ ਬਣਾਉਂਦਾ ਹੈ। ਇਸਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਸੋਚੋ ਕਿ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਇੱਕ ਟੂਲਬਾਕਸ ਵਿੱਚ ਪਲਗ ਕਰ ਰਹੇ ਹੋ ਜਿਸਨੂੰ ਇਹ *ਵਾਸਤਵ ਵਿੱਚ* ਵਰਤ ਸਕਦਾ ਹੈ।

ਮੰਨੋ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਕਨੈਕਟ ਕਰਦੇ ਹੋ। ਅਚਾਨਕ, ਤੁਹਾਡਾ ਏਜੰਟ ਸਿਰਫ "47 ਦਾ 89 ਨਾਲ ਗੁਣਨ ਕੀ ਹੈ?" ਵਰਗਾ ਪ੍ਰੰਪਟ ਪ੍ਰਾਪਤ ਕਰਕੇ ਗਣਿਤੀ ਕ੍ਰਿਆਵਾਂ ਕਰ ਸਕਦਾ ਹੈ—ਲੋਜਿਕ ਨੂੰ ਹਾਰਡਕੋਡ ਕਰਨ ਜਾਂ ਕਸਟਮ API ਬਣਾਉਣ ਦੀ ਲੋੜ ਨਹੀਂ।

## ਝਲਕ

ਇਹ ਪਾਠ ਕਿਵੇਂ ਇੱਕ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨੂੰ [AI Toolkit](https://aka.ms/AIToolkit) ਐਕਸਟੈਂਸ਼ਨ ਦੇ ਨਾਲ ਏਜੰਟ ਨਾਲ ਕਨੈਕਟ ਕਰਨਾ ਹੈ ਕਵਰ ਕਰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਤੁਹਾਡਾ ਏਜੰਟ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਜੋੜ, ਘਟਾਓ, ਗੁਣਨ, ਅਤੇ ਭਾਗ ਕਰਨ ਵਰਗੀਆਂ ਗਣਿਤੀ ਕ੍ਰਿਆਵਾਂ ਕਰਨ ਦੇ ਯੋਗ ਬਣਦਾ ਹੈ।

AI Toolkit ਵਿਜੁਅਲ ਸਟੂਡੀਓ ਕੋਡ ਲਈ ਇੱਕ ਸ਼ਕਤੀਸ਼ਾਲੀ ਐਕਸਟੈਂਸ਼ਨ ਹੈ ਜੋ ਏਜੰਟ ਵਿਕਾਸ ਨੂੰ ਸਧਾਰਨ ਬਣਾਉਂਦਾ ਹੈ। AI ਇੰਜੀਨੀਅਰ ਆਸਾਨੀ ਨਾਲ ਸਥਾਨਕ ਜਾਂ ਕਲਾਉਡ ਵਿੱਚ ਜਨਰੇਟਿਵ AI ਮਾਡਲ ਵਿਕਸਿਤ ਅਤੇ ਟੈਸਟ ਕਰਕੇ AI ਐਪਲੀਕੇਸ਼ਨ ਬਣਾ ਸਕਦੇ ਹਨ। ਐਕਸਟੈਂਸ਼ਨ ਅੱਜ ਉਪਲਬਧ ਬਹੁਤ ਸਾਰੇ ਮੁੱਖ ਜਨਰੇਟਿਵ ਮਾਡਲਾਂ ਨੂੰ ਸਹਾਇਕ ਹੈ।

*ਨੋਟ*: AI Toolkit ਵਰਤਮਾਨ ਵਿੱਚ ਪਾਇਥਨ ਅਤੇ ਟਾਈਪਸਕ੍ਰਿਪਟ ਨੂੰ ਸਹਾਇਕ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰਥ ਹੋਵੋਗੇ:

- AI Toolkit ਰਾਹੀਂ ਇੱਕ MCP ਸਰਵਰ ਦੀ ਖਪਤ ਕਰੋ।
- ਏਜੰਟ ਸੰਰਚਨਾ ਨੂੰ ਸੰਰਚਿਤ ਕਰੋ ਤਾਂ ਜੋ ਇਹ MCP ਸਰਵਰ ਦੁਆਰਾ ਪ੍ਰਦਾਨ ਕੀਤੇ ਟੂਲਾਂ ਦੀ ਖੋਜ ਅਤੇ ਵਰਤੋਂ ਕਰ ਸਕੇ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ MCP ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰੋ।

## ਦ੍ਰਿਸ਼ਟੀਕੋਣ

ਇਸਨੂੰ ਉੱਚ-ਸਤ੍ਹਾ ਤੇ ਕਿਵੇਂ ਕਰਨਾ ਹੈ:

- ਇੱਕ ਏਜੰਟ ਬਣਾਓ ਅਤੇ ਇਸਦਾ ਸਿਸਟਮ ਪ੍ਰੰਪਟ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ।
- ਕੈਲਕੂਲੇਟਰ ਟੂਲਾਂ ਦੇ ਨਾਲ ਇੱਕ MCP ਸਰਵਰ ਬਣਾਓ।
- Agent Builder ਨੂੰ MCP ਸਰਵਰ ਨਾਲ ਕਨੈਕਟ ਕਰੋ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਏਜੰਟ ਦੇ ਟੂਲ ਉਤਪੱਤੀ ਦੀ ਜਾਂਚ ਕਰੋ।

ਵਧੀਆ, ਹੁਣ ਕਿ ਸਾਨੂੰ ਫਲੋ ਸਮਝ ਆ ਗਿਆ ਹੈ, ਆਓ ਇੱਕ AI ਏਜੰਟ ਸੰਰਚਿਤ ਕਰੀਏ ਜੋ MCP ਰਾਹੀਂ ਬਾਹਰੀ ਟੂਲਾਂ ਦਾ ਲਾਭ ਲੈਂਦਾ ਹੈ, ਇਸਦੀ ਸਮਰਥਾ ਵਧਾਉਂਦਾ ਹੈ!

## ਪੂਰਵ ਸ਼ਰਤਾਂ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## ਅਭਿਆਸ: ਸਰਵਰ ਦੀ ਖਪਤ

ਇਸ ਅਭਿਆਸ ਵਿੱਚ, ਤੁਸੀਂ AI Toolkit ਵਰਤ ਕੇ Visual Studio Code ਵਿੱਚ ਇੱਕ MCP ਸਰਵਰ ਦੇ ਟੂਲਾਂ ਨਾਲ ਇੱਕ AI ਏਜੰਟ ਬਣਾਉਂਦੇ, ਚਲਾਉਂਦੇ, ਅਤੇ ਵਧਾਉਂਦੇ ਹੋ।

### -0- ਪ੍ਰੀਸਟੈਪ, My Models ਵਿੱਚ OpenAI GPT-4o ਮਾਡਲ ਸ਼ਾਮਲ ਕਰੋ

ਅਭਿਆਸ **GPT-4o** ਮਾਡਲ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ। ਏਜੰਟ ਬਣਾਉਣ ਤੋਂ ਪਹਿਲਾਂ ਮਾਡਲ ਨੂੰ **My Models** ਵਿੱਚ ਸ਼ਾਮਲ ਕੀਤਾ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ।

1. **AI Toolkit** ਐਕਸਟੈਂਸ਼ਨ ਨੂੰ **Activity Bar** ਤੋਂ ਖੋਲ੍ਹੋ।
1. **Catalog** ਸੈਕਸ਼ਨ ਵਿੱਚ, **Models** ਚੁਣੋ ਤਾਂ ਕਿ **Model Catalog** ਖੁਲ੍ਹੇ। **Models** ਚੁਣਨਾ **Model Catalog** ਨੂੰ ਇੱਕ ਨਵੀਂ ਸੰਪਾਦਕ ਟੈਬ ਵਿੱਚ ਖੋਲ੍ਹਦਾ ਹੈ।
1. **Model Catalog** ਖੋਜ ਬਾਰ ਵਿੱਚ **OpenAI GPT-4o** ਦਰਜ ਕਰੋ।
1. **+ Add** 'ਤੇ ਕਲਿੱਕ ਕਰੋ ਤਾਂ ਕਿ ਮਾਡਲ ਤੁਹਾਡੇ **My Models** ਸੂਚੀ ਵਿੱਚ ਸ਼ਾਮਲ ਹੋ ਜਾਵੇ। ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਸੀਂ **Hosted by GitHub** ਮਾਡਲ ਚੁਣਿਆ ਹੈ।
1. **Activity Bar** ਵਿੱਚ, ਪੁਸ਼ਟੀ ਕਰੋ ਕਿ **OpenAI GPT-4o** ਮਾਡਲ ਸੂਚੀ ਵਿੱਚ ਦਿਖਾਈ ਦਿੰਦਾ ਹੈ।

### -1- ਏਜੰਟ ਬਣਾਓ

**Agent (Prompt) Builder** ਤੁਹਾਨੂੰ ਆਪਣੇ AI-ਚਾਲਤ ਏਜੰਟਾਂ ਨੂੰ ਬਣਾਉਣ ਅਤੇ ਕਸਟਮਾਈਜ਼ ਕਰਨ ਦੀ ਯੋਗਤਾ ਦਿੰਦਾ ਹੈ। ਇਸ ਸੈਕਸ਼ਨ ਵਿੱਚ, ਤੁਸੀਂ ਇੱਕ ਨਵਾਂ ਏਜੰਟ ਬਣਾਉਗੇ ਅਤੇ ਮਾਡਲ ਨੂੰ ਸੰਵਾਦ ਸ਼ਕਤੀ ਦੇਣ ਲਈ ਨਿਰਧਾਰਤ ਕਰੋਗੇ।

1. **AI Toolkit** ਐਕਸਟੈਂਸ਼ਨ ਨੂੰ **Activity Bar** ਤੋਂ ਖੋਲ੍ਹੋ।
1. **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ, **Agent (Prompt) Builder** ਚੁਣੋ। **Agent (Prompt) Builder** ਚੁਣਨਾ **Agent (Prompt) Builder** ਨੂੰ ਇੱਕ ਨਵੀਂ ਸੰਪਾਦਕ ਟੈਬ ਵਿੱਚ ਖੋਲ੍ਹਦਾ ਹੈ।
1. **+ New Builder** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਐਕਸਟੈਂਸ਼ਨ **Command Palette** ਰਾਹੀਂ ਸੈਟਅਪ ਵਿੱਜ਼ਰਡ ਲਾਂਚ ਕਰੇਗਾ।
1. ਨਾਮ **Calculator Agent** ਦਰਜ ਕਰੋ ਅਤੇ **Enter** ਦਬਾਓ।
1. **Agent (Prompt) Builder** ਵਿੱਚ, **Model** ਫੀਲਡ ਲਈ, **OpenAI GPT-4o (via GitHub)** ਮਾਡਲ ਚੁਣੋ।

### -2- ਏਜੰਟ ਲਈ ਸਿਸਟਮ ਪ੍ਰੰਪਟ ਬਣਾਓ

ਏਜੰਟ ਨੂੰ ਫਰੈਮਵਰਕ ਦੇਣ ਦੇ ਨਾਲ, ਇਸਦਾ ਵਿਅਕਤਿਤਾ ਅਤੇ ਉਦੇਸ਼ ਪਰਿਭਾਸ਼ਿਤ ਕਰਨ ਦਾ ਸਮਾਂ ਹੈ। ਇਸ ਸੈਕਸ਼ਨ ਵਿੱਚ, ਤੁਸੀਂ **Generate system prompt** ਫੀਚਰ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਏਜੰਟ ਦੇ ਇਰਾਦੇਵਾਲੇ ਵਿਆਖਿਆ ਕਰੋਗੇ—ਇਸ ਮਾਮਲੇ ਵਿੱਚ, ਇੱਕ ਕੈਲਕੂਲੇਟਰ ਏਜੰਟ—ਅਤੇ ਮਾਡਲ ਨੂੰ ਸਿਸਟਮ ਪ੍ਰੰਪਟ ਤੁਹਾਡੇ ਲਈ ਲਿਖਣ ਦਿਓਗੇ।

1. **Prompts** ਸੈਕਸ਼ਨ ਲਈ, **Generate system prompt** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਇਹ ਬਟਨ ਪ੍ਰੰਪਟ ਬਿਲਡਰ ਵਿੱਚ ਖੁਲ੍ਹਦਾ ਹੈ ਜੋ ਏਜੰਟ ਲਈ ਸਿਸਟਮ ਪ੍ਰੰਪਟ ਜਨਰੇਟ ਕਰਨ ਲਈ AI ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ।
1. **Generate a prompt** ਵਿੰਡੋ ਵਿੱਚ, ਹੇਠ ਲਿਖਿਆ ਦਰਜ ਕਰੋ: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਇੱਕ ਨੋਟੀਫਿਕੇਸ਼ਨ ਨੀਚੇ-ਸੱਜੇ ਕੋਨੇ ਵਿੱਚ ਪ੍ਰਦਰਸ਼ਿਤ ਹੋਵੇਗਾ ਜੋ ਸਿਸਟਮ ਪ੍ਰੰਪਟ ਜਨਰੇਟ ਹੋ ਰਿਹਾ ਹੈ। ਜਦੋਂ ਪ੍ਰੰਪਟ ਜਨਰੇਸ਼ਨ ਪੂਰਾ ਹੋ ਜਾਂਦਾ ਹੈ, ਪ੍ਰੰਪਟ **Agent (Prompt) Builder** ਦੇ **System prompt** ਫੀਲਡ ਵਿੱਚ ਪ੍ਰਦਰਸ਼ਿਤ ਹੋਵੇਗਾ।
1. **System prompt** ਦੀ ਸਮੀਖਿਆ ਕਰੋ ਅਤੇ ਜਰੂਰਤ ਪੈਣ 'ਤੇ ਸੋਧ ਕਰੋ।

### -3- MCP ਸਰਵਰ ਬਣਾਓ

ਹੁਣ ਕਿ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਦੇ ਸਿਸਟਮ ਪ੍ਰੰਪਟ—ਇਸਦੇ ਵਿਹਾਰ ਅਤੇ ਜਵਾਬਾਂ ਨੂੰ ਮਾਰਗਦਰਸ਼ਨ ਦੇਣ ਵਾਲਾ—ਨਿਰਧਾਰਤ ਕੀਤਾ ਹੈ, ਇਹ ਸਮਾਂ ਹੈ ਕਿ ਏਜੰਟ ਨੂੰ ਵਾਸਤਵਿਕ ਸਮਰਥਾਵਾਂ ਦੇ ਨਾਲ ਸਜਾਇਆ ਜਾਵੇ। ਇਸ ਸੈਕਸ਼ਨ ਵਿੱਚ, ਤੁਸੀਂ ਜੋੜ, ਘਟਾਓ, ਗੁਣਨ, ਅਤੇ ਭਾਗ ਕਰਨ ਦੀਆਂ ਗਣਿਤੀ ਕ੍ਰਿਆਵਾਂ ਕਰਨ ਲਈ ਟੂਲਾਂ ਦੇ ਨਾਲ ਇੱਕ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਗੇ। ਇਹ ਸਰਵਰ ਤੁਹਾਡੇ ਏਜੰਟ ਨੂੰ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਪ੍ਰੰਪਟਾਂ ਦੇ ਜਵਾਬ ਵਿੱਚ ਵਾਸਤਵਿਕ ਸਮੇਂ ਗਣਿਤੀ ਕ੍ਰਿਆਵਾਂ ਕਰਨ ਦੇ ਯੋਗ ਬਣਾਏਗਾ।

AI Toolkit ਆਪਣੇ MCP ਸਰਵਰ ਨੂੰ ਬਣਾਉਣ ਲਈ ਟੈਮਪਲੇਟਾਂ ਨਾਲ ਸਜਾਇਆ ਗਿਆ ਹੈ। ਅਸੀਂ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਪਾਇਥਨ ਟੈਮਪਲੇਟ ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ।

*ਨੋਟ*: AI Toolkit ਵਰਤਮਾਨ ਵਿੱਚ ਪਾਇਥਨ ਅਤੇ ਟਾਈਪਸਕ੍ਰਿਪਟ ਨੂੰ ਸਹਾਇਕ ਹੈ।

1. **Agent (Prompt) Builder** ਦੇ **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ, **+ MCP Server** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਐਕਸਟੈਂਸ਼ਨ **Command Palette** ਰਾਹੀਂ ਸੈਟਅਪ ਵਿੱਜ਼ਰਡ ਲਾਂਚ ਕਰੇਗਾ।
1. **+ Add Server** ਚੁਣੋ।
1. **Create a New MCP Server** ਚੁਣੋ।
1. **python-weather** ਨੂੰ ਟੈਮਪਲੇਟ ਵਜੋਂ ਚੁਣੋ।
1. MCP ਸਰਵਰ ਟੈਮਪਲੇਟ ਨੂੰ ਸੇਵ ਕਰਨ ਲਈ **Default folder** ਚੁਣੋ।
1. ਸਰਵਰ ਲਈ ਹੇਠ ਲਿਖਿਆ ਨਾਮ ਦਰਜ ਕਰੋ: **Calculator**
1. ਇੱਕ ਨਵਾਂ Visual Studio Code ਵਿੰਡੋ ਖੁਲ੍ਹੇਗਾ। **Yes, I trust the authors** ਚੁਣੋ।
1. ਟਰਮੀਨਲ ਦੀ ਵਰਤੋਂ ਕਰਕੇ, ਇੱਕ ਵਰਚੁਅਲ ਵਾਤਾਵਰਨ ਬਣਾਓ: `python -m venv .venv`
1. ਟਰਮੀਨਲ ਦੀ ਵਰਤੋਂ ਕਰਕੇ, ਵਰਚੁਅਲ ਵਾਤਾਵਰਨ ਨੂੰ ਐਕਟੀਵੇਟ ਕਰੋ:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ਟਰਮੀਨਲ ਦੀ ਵਰਤੋਂ ਕਰਕੇ, Dependencies ਨੂੰ ਇੰਸਟਾਲ ਕਰੋ: `pip install -e .[dev]`
1. **Activity Bar** ਦੇ **Explorer** ਦ੍ਰਿਸ਼ਟੀਕੋਣ ਵਿੱਚ, **src** ਡਾਇਰੈਕਟਰੀ ਨੂੰ ਵਧਾਓ ਅਤੇ **server.py** ਨੂੰ ਸੰਪਾਦਕ ਵਿੱਚ ਫਾਈਲ ਖੋਲ੍ਹਣ ਲਈ ਚੁਣੋ।
1. **server.py** ਫਾਈਲ ਵਿੱਚ ਕੋਡ ਨੂੰ ਹੇਠ ਲਿਖੇ ਨਾਲ ਬਦਲੋ ਅਤੇ ਸੇਵ ਕਰੋ:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਏਜੰਟ ਚਲਾਓ

ਹੁਣ ਕਿ ਤੁਹਾਡੇ ਏਜੰਟ ਕੋਲ ਟੂਲ ਹਨ, ਇਹ ਸਮਾਂ ਹੈ ਕਿ ਇਹਨਾਂ ਦੀ ਵਰਤੋਂ ਕੀਤੀ ਜਾਵੇ! ਇਸ ਸੈਕਸ਼ਨ ਵਿੱਚ, ਤੁਸੀਂ ਏਜੰਟ ਨੂੰ ਪ੍ਰੰਪਟਸ ਭੇਜੋਗੇ ਤਾਂ ਕਿ ਜਾਂਚ ਅਤੇ ਪੁਸ਼ਟੀ ਕੀਤੀ ਜਾਵੇ ਕਿ ਏਜੰਟ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਤੋਂ ਉਚਿਤ ਟੂਲ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਕਿ ਨਹੀਂ।

ਤੁਸੀਂ ਆਪਣੇ ਸਥਾਨਕ ਡਿਵ ਮਸ਼ੀਨ 'ਤੇ **Agent Builder** ਰਾਹੀਂ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਚਲਾਓਗੇ ਜਿਵੇਂ ਕਿ MCP ਕਲਾਇੰਟ।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ਮੁੱਲ **subtract** ਟੂਲ ਲਈ ਦਿੱਤੇ ਗਏ ਹਨ।
    - ਹਰ ਟੂਲ ਤੋਂ ਪ੍ਰਤੀਕ੍ਰਿਆ ਸਬੰਧਿਤ **Tool Response** ਵਿੱਚ ਦਿੱਤੀ ਜਾਂਦੀ ਹੈ।
    - ਮਾਡਲ ਤੋਂ ਅੰਤਮ ਆਉਟਪੁੱਟ ਅੰਤਮ **Model Response** ਵਿੱਚ ਦਿੱਤਾ ਜਾਂਦਾ ਹੈ।
1. ਏਜੰਟ ਦੀ ਅਗਲੇ ਟੈਸਟ ਲਈ ਹੋਰ ਪ੍ਰੰਪਟਸ ਭੇਜੋ। ਤੁਸੀਂ **User prompt** ਫੀਲਡ ਵਿੱਚ ਮੌਜੂਦਾ ਪ੍ਰੰਪਟ ਨੂੰ ਸੋਧ ਕੇ ਪ੍ਰੰਪਟ ਨੂੰ ਸੋਧ ਸਕਦੇ ਹੋ।
1. ਜਦੋਂ ਤੁਸੀਂ ਏਜੰਟ ਦੀ ਜਾਂਚ ਕਰ ਲੈਂਦੇ ਹੋ, ਤੁਸੀਂ **terminal** ਰਾਹੀਂ ਸਰਵਰ ਨੂੰ ਬੰਦ ਕਰ ਸਕਦੇ ਹੋ **CTRL/CMD+C** ਦਰਜ ਕਰਕੇ।

## ਅਸਾਈਨਮੈਂਟ

ਆਪਣੀ **server.py** ਫਾਈਲ ਵਿੱਚ ਇੱਕ ਹੋਰ ਟੂਲ ਐਂਟਰੀ ਸ਼ਾਮਲ ਕਰਨ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ (ਜਿਵੇਂ: ਇੱਕ ਨੰਬਰ ਦਾ ਵਰਗ ਮੂਲ ਵਾਪਸ ਕਰੋ)। ਅਜਿਹੇ ਹੋਰ ਪ੍ਰੰਪਟਸ ਭੇਜੋ ਜੋ ਤੁਹਾਡੇ ਨਵੇਂ ਟੂਲ (ਜਾਂ ਮੌਜੂਦਾ ਟੂਲ) ਦੀ ਵਰਤੋਂ ਕਰਨ ਦੀ ਲੋੜ ਹੋਵੇ। ਨਵਾਂ ਸ਼ਾਮਲ ਕੀਤਾ ਟੂਲ ਲੋਡ ਕਰਨ ਲਈ ਸਰਵਰ ਨੂੰ ਦੁਬਾਰਾ ਚਲਾਉਣਾ ਯਕੀਨੀ ਬਣਾਓ।

## ਹੱਲ

[Solution](./solution/README.md)

## ਮੁੱਖ ਬਿੰਦੂ

ਇਸ ਅਧਿਆਇ ਦੇ ਮੁੱਖ ਬਿੰਦੂ ਇਹ ਹਨ:

- AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਇੱਕ ਸ਼ਾਨਦਾਰ ਕਲਾਇੰਟ ਹੈ ਜੋ ਤੁਹਾਨੂੰ MCP ਸਰਵਰ ਅਤੇ ਇਸਦੇ ਟੂਲ ਦੀ ਖਪਤ ਕਰਨ ਦਿੰਦਾ ਹੈ।
- ਤੁਸੀਂ MCP ਸਰਵਰਾਂ ਵਿੱਚ ਨਵੇਂ ਟੂਲ ਸ਼ਾਮਲ ਕਰ ਸਕਦੇ ਹੋ, ਏਜੰਟ ਦੀ ਸਮਰਥਾ ਨੂੰ ਵਧਾਉਂਦੇ ਹੋਵੇਂ ਵਿਕਾਸਮਾਨ ਜ਼ਰੂਰਤਾਂ ਨੂੰ ਪੂਰਾ ਕਰਨ ਲਈ।
- AI Toolkit ਵਿੱਚ ਟੈਮਪਲੇਟ (ਜਿਵੇਂ, ਪਾਇਥਨ MCP ਸਰਵਰ ਟੈਮਪਲੇਟ) ਸ਼ਾਮਲ ਹਨ ਜੋ ਕਸਟਮ ਟੂਲ ਬਣਾਉਣ ਨੂੰ ਸਧਾਰਨ ਬਣਾਉਂਦੇ ਹਨ।

## ਵਧੇਰੇ ਸਾਧਨ

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## ਅਗਲਾ ਕੀ ਹੈ

ਅਗਲਾ: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**ਅਸਵੀਕਤੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਹਾਲਾਂਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦਾ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਵਿਧਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸ ਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਗੰਭੀਰ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।