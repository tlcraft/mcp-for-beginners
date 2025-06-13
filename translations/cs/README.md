<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26ab12045ee411ab7ad0eb0b1b7b1cbb",
  "translation_date": "2025-06-13T00:54:22+00:00",
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


Folgen Sie diesen Schritten, um mit der Nutzung dieser Ressourcen zu beginnen:
1. **Forken Sie das Repository**: Klicken Sie auf [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klonen Sie das Repository**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Treten Sie dem Azure AI Foundry Discord bei und treffen Sie Experten sowie andere Entwickler**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Mehrsprachige Unterstützung

#### Unterstützt durch GitHub Action (Automatisiert & immer aktuell)

# 🚀 Model Context Protocol (MCP) Müfredatı Yeni Başlayanlar İçin

## **C#, Java, JavaScript, Python ve TypeScript ile Uygulamalı MCP Öğrenin**

## 🧠 Model Context Protocol Müfredatına Genel Bakış

**Model Context Protocol (MCP)**, yapay zeka modelleri ile istemci uygulamalar arasındaki etkileşimleri standartlaştırmak için tasarlanmış ileri seviye bir çerçevedir. Bu açık kaynak müfredat, C#, Java, JavaScript, TypeScript ve Python gibi popüler programlama dillerinde pratik kod örnekleri ve gerçek dünya kullanım senaryolarıyla yapılandırılmış bir öğrenme yolu sunar.

İster bir yapay zeka geliştiricisi, sistem mimarı, ister yazılım mühendisi olun, bu rehber MCP temellerini ve uygulama stratejilerini ustalıkla öğrenmeniz için kapsamlı bir kaynaktır.

## 🔗 Resmi MCP Kaynakları

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Detaylı eğitimler ve kullanıcı rehberleri  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Protokol mimarisi ve teknik referanslar  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Açık kaynak SDK’lar, araçlar ve kod örnekleri  

## 🧭 Tam MCP Müfredat Yapısı

| Bölüm | Başlık | Açıklama | Bağlantı |
|--|--|--|--|
| 00 | **MCP’ye Giriş** | Model Context Protocol’ün genel tanıtımı ve AI iş akışlarındaki önemi, MCP nedir, neden standartlaşma önemli, pratik kullanım örnekleri ve faydaları | [Introduction](./00-Introduction/README.md) |
| 01 | **Temel Kavramlar** | MCP’nin temel kavramlarının detaylı incelenmesi; istemci-sunucu mimarisi, ana protokol bileşenleri ve mesajlaşma kalıpları | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **MCP’de Güvenlik** | MCP tabanlı sistemlerde güvenlik tehditlerinin tanımlanması, güvenli uygulama teknikleri ve en iyi uygulamalar | [Security](/02-Security/README.md) |
| 03 | **MCP’ye Başlarken** | Ortam kurulumu ve yapılandırması, temel MCP sunucu ve istemcilerinin oluşturulması, MCP’nin mevcut uygulamalarla entegrasyonu | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **İlk sunucu** | MCP protokolü kullanarak temel bir sunucu kurma, sunucu-istemci etkileşimini anlama ve sunucuyu test etme | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **İlk istemci** | MCP protokolü ile temel bir istemci kurma, istemci-sunucu etkileşimini anlama ve istemciyi test etme | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLM ile İstemci** | MCP protokolü kullanarak Büyük Dil Modeli (LLM) destekli bir istemci kurma | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Code ile Sunucu Tüketimi** | Visual Studio Code’u MCP protokolü kullanan sunucuları tüketmek için yapılandırma | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSE ile Sunucu Oluşturma** | SSE, bir sunucuyu internete açmamıza yardımcı olur. Bu bölümde SSE kullanarak sunucu oluşturmayı öğreneceksiniz | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit Kullanımı** | AI toolkit, AI ve MCP iş akışınızı yönetmenize yardımcı olacak harika bir araçtır. | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Sunucunuzu Test Etme** | Test etmek geliştirme sürecinin önemli bir parçasıdır. Bu bölümde çeşitli araçlarla test yapmayı öğreneceksiniz. | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Sunucunuzu Dağıtma** | Yerel geliştirmeden üretime geçiş nasıl yapılır? Bu bölüm sunucunuzu geliştirme ve dağıtma sürecinde size yardımcı olacak. | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Pratik Uygulama** | Farklı dillerde SDK kullanımı, hata ayıklama, test ve doğrulama, yeniden kullanılabilir prompt şablonları ve iş akışları oluşturma | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **MCP’de İleri Konular** | Çok modlu AI iş akışları ve genişletilebilirlik, güvenli ölçeklendirme stratejileri, MCP’nin kurumsal ekosistemlerde kullanımı | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Azure ile MCP Entegrasyonu** | Azure entegrasyonunu gösterir | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Çok Modluluk** | Görüntüler ve diğer modlar gibi farklı modalitelerle çalışma | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | MCP ile OAuth2’yi gösteren minimal Spring Boot uygulaması; hem Yetkilendirme hem de Kaynak Sunucusu olarak. Güvenli token verme, korumalı uç noktalar, Azure Container Apps dağıtımı ve API Yönetimi entegrasyonunu gösterir. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Root context hakkında daha fazla bilgi edinin ve nasıl uygulanacağını öğrenin | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Farklı routing türlerini öğrenin | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Sampling ile nasıl çalışılacağını öğrenin | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Ölçeklendirme** | MCP sunucularını yatay ve dikey ölçeklendirme stratejileri, kaynak optimizasyonu ve performans ayarları dahil olmak üzere ölçeklendirme hakkında bilgi edinin | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Güvenlik** | MCP sunucunuzu güvence altına alma; kimlik doğrulama, yetkilendirme ve veri koruma stratejileri | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP sunucu ve istemcisi, SerpAPI ile gerçek zamanlı web, haber, ürün araması ve Soru-Cevap entegrasyonu. Çoklu araç orkestrasyonu, dış API entegrasyonu ve sağlam hata yönetimini gösterir | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Gerçek Zamanlı Akış** | Günümüzün veri odaklı dünyasında gerçek zamanlı veri akışı hayati önem kazanmıştır; işletmeler ve uygulamalar anında bilgiye erişimle zamanında kararlar alabilir. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Gerçek Zamanlı Web Arama** | MCP’nin AI modelleri, arama motorları ve uygulamalar arasında bağlam yönetimini standartlaştırarak gerçek zamanlı web aramasını nasıl dönüştürdüğünü öğrenin. | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Topluluk Katkıları** | Kod ve doküman katkısı yapma, GitHub üzerinden iş birliği, topluluk odaklı geliştirmeler ve geri bildirimler | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Erken Benimsemeden Alınan Dersler** | Gerçek dünya uygulamaları ve işe yarayanlar, MCP tabanlı çözümler geliştirme ve dağıtma, trendler ve geleceğe dair yol haritası | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Mejores Prácticas para MCP** | Ajuste de rendimiento y optimización, diseño de sistemas MCP tolerantes a fallos, estrategias de prueba y resiliencia | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Estudios de Caso MCP** | Análisis detallados de arquitecturas de soluciones MCP, planos de despliegue y consejos de integración, diagramas anotados y recorridos de proyectos | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Optimización de Flujos de Trabajo de IA: Construyendo un Servidor MCP con AI Toolkit** | Taller práctico completo que combina MCP con AI Toolkit de Microsoft para VS Code. Aprende a crear aplicaciones inteligentes que conectan modelos de IA con herramientas del mundo real mediante módulos prácticos que cubren fundamentos, desarrollo de servidores personalizados y estrategias de despliegue en producción. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Proyectos de Ejemplo

### 🧮 Proyectos de Calculadora MCP:
<details>
  <summary><strong>Explora implementaciones de código por lenguaje</strong></summary>

  - [Ejemplo de Servidor MCP en C#](./03-GettingStarted/samples/csharp/README.md)
  - [Calculadora MCP en Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP en JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Servidor MCP en Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Ejemplo MCP en TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Proyectos Avanzados de Calculadora MCP:
<details>
  <summary><strong>Explora ejemplos avanzados</strong></summary>

  - [Ejemplo Avanzado en C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Ejemplo de Aplicación Contenedor en Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Ejemplo Avanzado en JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementación Compleja en Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Ejemplo de Contenedor en TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Requisitos Previos para Aprender MCP

Para aprovechar al máximo este plan de estudios, deberías tener:

- Conocimientos básicos de C#, Java o Python
- Comprensión del modelo cliente-servidor y APIs
- (Opcional) Familiaridad con conceptos de aprendizaje automático

## 📚 Guía de Estudio

Hay una [Guía de Estudio](./study_guide.md) completa disponible para ayudarte a navegar este repositorio de manera efectiva. La guía incluye:

- Un mapa visual del plan de estudios con todos los temas cubiertos
- Desglose detallado de cada sección del repositorio
- Instrucciones sobre cómo usar los proyectos de ejemplo
- Rutas de aprendizaje recomendadas para diferentes niveles de habilidad
- Recursos adicionales para complementar tu proceso de aprendizaje

## 🛠️ Cómo Usar Este Plan de Estudios de Forma Efectiva

Cada lección en esta guía incluye:

1. Explicaciones claras de los conceptos MCP  
2. Ejemplos de código en vivo en varios lenguajes  
3. Ejercicios para construir aplicaciones MCP reales  
4. Recursos extra para estudiantes avanzados  

## 📜 Información de Licencia

Este contenido está bajo la **Licencia MIT**. Para términos y condiciones, consulta el [LICENSE](../../LICENSE).

## 🤝 Directrices para Contribuciones

Este proyecto acepta contribuciones y sugerencias. La mayoría de las contribuciones requieren que aceptes un
Acuerdo de Licencia de Contribuidor (CLA) declarando que tienes el derecho y efectivamente nos otorgas
los derechos para usar tu contribución. Para más detalles, visita <https://cla.opensource.microsoft.com>.

Cuando envíes una solicitud de extracción, un bot CLA determinará automáticamente si necesitas proporcionar
un CLA y marcará el PR adecuadamente (por ejemplo, chequeo de estado, comentario). Solo sigue las instrucciones
del bot. Solo tendrás que hacer esto una vez para todos los repositorios que usan nuestro CLA.

Este proyecto ha adoptado el [Código de Conducta de Código Abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para más información, consulta las [Preguntas Frecuentes sobre el Código de Conducta](https://opensource.microsoft.com/codeofconduct/faq/) o
contacta a [opencode@microsoft.com](mailto:opencode@microsoft.com) para cualquier pregunta o comentario adicional.

## 🎒 Otros Cursos
¡Nuestro equipo produce otros cursos! Echa un vistazo a:

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


## ™️ 공지 상표권

이 프로젝트에는 프로젝트, 제품 또는 서비스의 상표나 로고가 포함될 수 있습니다. Microsoft 상표 또는 로고의 허가된 사용은
[Microsoft의 상표 및 브랜드 가이드라인](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)을 준수해야 합니다.
수정된 버전의 프로젝트에서 Microsoft 상표 또는 로고를 사용하는 경우 혼동을 일으키거나 Microsoft의 후원을 암시해서는 안 됩니다.
제3자 상표 또는 로고의 사용은 해당 제3자의 정책에 따릅니다.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.