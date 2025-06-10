<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3ede7f051090bd4acfe5b068bab9f6b0",
  "translation_date": "2025-06-10T04:37:52+00:00",
  "source_file": "README.md",
  "language_code": "cs"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.cs.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Siga estos pasos para comenzar a usar estos recursos:
1. **Haz un fork del repositorio**: Haz clic en [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clona el repositorio**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Únete al Discord de Azure AI Foundry y conoce a expertos y otros desarrolladores**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Soporte multilingüe

#### Soportado mediante GitHub Action (Automatizado y siempre actualizado)

# 🚀 Model Context Protocol (MCP) Müfredatı Başlangıç Seviyesi İçin

## **C#, Java, JavaScript, Python ve TypeScript ile Uygulamalı MCP Öğrenin**

## 🧠 Model Context Protocol Müfredatına Genel Bakış

**Model Context Protocol (MCP)**, AI modelleri ile istemci uygulamalar arasındaki etkileşimleri standartlaştırmak için tasarlanmış ileri seviye bir çerçevedir. Bu açık kaynak müfredat, C#, Java, JavaScript, TypeScript ve Python gibi popüler programlama dillerinde pratik kod örnekleri ve gerçek dünya kullanım senaryolarıyla yapılandırılmış bir öğrenme yolu sunar.

İster bir AI geliştiricisi, sistem mimarı, ister yazılım mühendisi olun, bu rehber MCP temel bilgilerini ve uygulama stratejilerini ustalıkla öğrenmeniz için kapsamlı bir kaynaktır.

## 🔗 Resmi MCP Kaynakları

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Detaylı eğitimler ve kullanıcı rehberleri  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Protokol mimarisi ve teknik referanslar  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Açık kaynak SDK’lar, araçlar ve kod örnekleri  

## 🧭 MCP Müfredatının Tam Yapısı

| Ch | Başlık | Açıklama | Link |
|--|--|--|--|
| 00 | **MCP’ye Giriş** | Model Context Protocol’ün genel tanıtımı ve AI süreçlerindeki önemi, MCP nedir, neden standartlaşma önemli, pratik kullanım senaryoları ve faydaları | [Introduction](./00-Introduction/README.md) |
| 01 | **Temel Kavramlar Açıklaması** | MCP’nin temel kavramlarının detaylı incelenmesi, istemci-sunucu mimarisi, ana protokol bileşenleri ve mesajlaşma desenleri | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **MCP’de Güvenlik** | MCP tabanlı sistemlerde güvenlik tehditlerinin tanımlanması, güvenli uygulamalar için teknikler ve en iyi uygulamalar | [Security](/02-Security/README.md) |
| 03 | **MCP’ye Başlarken** | Ortam kurulumu ve yapılandırma, temel MCP sunucu ve istemcilerinin oluşturulması, MCP’nin mevcut uygulamalara entegrasyonu | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **İlk Sunucu** | MCP protokolü kullanarak temel bir sunucu kurulumu, sunucu-istemci etkileşiminin anlaşılması ve sunucunun test edilmesi | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **İlk İstemci** | MCP protokolü kullanarak temel bir istemci kurulumu, istemci-sunucu etkileşiminin anlaşılması ve istemcinin test edilmesi | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLM ile İstemci** | MCP protokolü kullanarak Büyük Dil Modeli (LLM) ile çalışan bir istemci kurulumu | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Code ile Sunucu Tüketimi** | Visual Studio Code’u MCP protokolü kullanan sunucuları tüketmek için yapılandırma | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSE ile Sunucu Oluşturma** | SSE, sunucuyu internete açmamıza yardımcı olur. Bu bölüm SSE kullanarak sunucu oluşturmanıza destek olur | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit Kullanımı** | AI Toolkit, AI ve MCP iş akışınızı yönetmenize yardımcı olacak harika bir araçtır. | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Sunucunuzu Test Etme** | Test etmek geliştirme sürecinin önemli bir parçasıdır. Bu bölüm farklı araçları kullanarak test yapmanıza yardımcı olur. | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Sunucunuzu Dağıtma** | Yerel geliştirmeden üretime geçiş nasıl yapılır? Bu bölüm sunucunuzu geliştirip dağıtmanıza yardımcı olur. | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Pratik Uygulama** | Farklı dillerde SDK kullanımı, hata ayıklama, test ve doğrulama, yeniden kullanılabilir prompt şablonları ve iş akışları oluşturma | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **MCP’de İleri Konular** | Çok modlu AI iş akışları ve genişletilebilirlik, güvenli ölçeklendirme stratejileri, MCP’nin kurumsal ekosistemlerde kullanımı | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Azure ile MCP Entegrasyonu** | Azure ile entegrasyon gösterimi | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Çoklu Modalite** | Görüntüler ve diğer modalitelerle çalışma yöntemleri | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | OAuth2 ile MCP’yi gösteren minimal Spring Boot uygulaması, hem Yetkilendirme hem Kaynak Sunucusu olarak. Güvenli token oluşturma, korumalı uç noktalar, Azure Container Apps dağıtımı ve API Yönetimi entegrasyonunu gösterir. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Root context hakkında daha fazla bilgi ve nasıl uygulanacağı | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Yönlendirme** | Farklı yönlendirme türlerini öğrenin | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Örnekleme** | Örnekleme ile nasıl çalışılacağını öğrenin | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Ölçeklendirme** | MCP sunucularını yatay ve dikey ölçeklendirme stratejileri, kaynak optimizasyonu ve performans ayarlamaları ile öğrenin | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Güvenlik** | MCP Sunucunuzu güvence altına alın; kimlik doğrulama, yetkilendirme ve veri koruma stratejileri dahil | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | SerpAPI ile gerçek zamanlı web, haber, ürün arama ve SSS için Python MCP sunucu ve istemcisi. Çoklu araç orkestrasyonu, dış API entegrasyonu ve sağlam hata yönetimi gösterir | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Topluluk Katkıları** | Kod ve doküman katkısı yapma, GitHub üzerinden iş birliği, topluluk odaklı geliştirmeler ve geri bildirim | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Erken Benimsemeden Alınan Dersler** | Gerçek dünya uygulamaları ve işe yarayanlar, MCP tabanlı çözümler geliştirme ve dağıtma, trendler ve gelecek yol haritası | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP için En İyi Uygulamalar** | Performans ayarı ve optimizasyon, hata toleranslı MCP sistemleri tasarımı, test ve dayanıklılık stratejileri | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP Vaka Çalışmaları** | MCP çözüm mimarileri, dağıtım şablonları ve entegrasyon ipuçları üzerine derinlemesine incelemeler, açıklamalı diyagramlar ve proje anlatımları | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Optimización de flujos de trabajo con IA: Creación de un servidor MCP con AI Toolkit** | Taller práctico integral que combina MCP con el AI Toolkit de Microsoft para VS Code. Aprende a construir aplicaciones inteligentes que integran modelos de IA con herramientas reales a través de módulos prácticos que cubren fundamentos, desarrollo de servidores personalizados y estrategias de despliegue en producción. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Proyectos de ejemplo

### 🧮 Proyectos de ejemplo del calculador MCP:
<details>
  <summary><strong>Explora implementaciones de código por lenguaje</strong></summary>

  - [Ejemplo de servidor MCP en C#](./03-GettingStarted/samples/csharp/README.md)
  - [Calculadora MCP en Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP en JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Servidor MCP en Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Ejemplo MCP en TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Proyectos avanzados de calculadora MCP:
<details>
  <summary><strong>Explora ejemplos avanzados</strong></summary>

  - [Ejemplo avanzado en C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Ejemplo de aplicación contenedor en Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Ejemplo avanzado en JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementación compleja en Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Ejemplo contenedor en TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Requisitos previos para aprender MCP

Para aprovechar al máximo este plan de estudios, deberías tener:

- Conocimientos básicos de C#, Java o Python  
- Comprensión del modelo cliente-servidor y APIs  
- (Opcional) Familiaridad con conceptos de aprendizaje automático  

## 🛠️ Cómo usar este plan de estudios de forma efectiva

Cada lección en esta guía incluye:

1. Explicaciones claras de los conceptos MCP  
2. Ejemplos de código en vivo en varios lenguajes  
3. Ejercicios para construir aplicaciones MCP reales  
4. Recursos adicionales para quienes deseen profundizar  

## 📜 Información sobre la licencia

Este contenido está licenciado bajo la **Licencia MIT**. Para términos y condiciones, consulta el [LICENSE](../../LICENSE).

## 🤝 Directrices para contribuciones

Este proyecto acepta contribuciones y sugerencias. La mayoría requieren que aceptes un
Acuerdo de Licencia para Contribuidores (CLA) declarando que tienes el derecho y realmente otorgas
los derechos para usar tu contribución. Para más detalles, visita <https://cla.opensource.microsoft.com>.

Cuando envíes un pull request, un bot de CLA determinará automáticamente si necesitas proporcionar
un CLA y marcará el PR apropiadamente (por ejemplo, verificación de estado, comentario). Solo sigue las instrucciones
del bot. Solo necesitarás hacer esto una vez para todos los repositorios que usen nuestro CLA.

Este proyecto ha adoptado el [Código de Conducta de Código Abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para más información, consulta las [Preguntas frecuentes sobre el Código de Conducta](https://opensource.microsoft.com/codeofconduct/faq/) o
contacta a [opencode@microsoft.com](mailto:opencode@microsoft.com) para cualquier pregunta o comentario adicional.

## 🎒 Otros cursos
¡Nuestro equipo produce otros cursos! Revisa:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Aviso de marca registrada

Este proyecto puede contener marcas o logotipos de proyectos, productos o servicios. El uso autorizado de las marcas o logotipos de Microsoft está sujeto y debe cumplir con
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
El uso de marcas o logotipos de Microsoft en versiones modificadas de este proyecto no debe causar confusión ni implicar patrocinio de Microsoft.
Cualquier uso de marcas o logotipos de terceros está sujeto a las políticas de esos terceros.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.