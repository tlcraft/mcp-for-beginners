<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3b97186cd9162b9fe9b90261e63e32d",
  "translation_date": "2025-06-13T14:27:00+00:00",
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


Siga estes passos para começar a usar esses recursos:
1. **Faça um Fork do Repositório**: Clique em [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clone o Repositório**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Junte-se ao Azure AI Foundry Discord e conheça especialistas e outros desenvolvedores**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Suporte Multilíngue

#### Suportado via GitHub Action (Automatizado e Sempre Atualizado)

# 🚀 Model Context Protocol (MCP) Müfredatı Yeni Başlayanlar için

## **C#, Java, JavaScript, Python ve TypeScript ile Uygulamalı MCP Öğrenin**

## 🧠 Model Context Protocol Müfredatına Genel Bakış

**Model Context Protocol (MCP)**, AI modelleri ile istemci uygulamalar arasındaki etkileşimleri standartlaştırmak için tasarlanmış ileri düzey bir çerçevedir. Bu açık kaynak müfredat, C#, Java, JavaScript, TypeScript ve Python gibi popüler programlama dillerinde pratik kod örnekleri ve gerçek dünya kullanım senaryolarıyla yapılandırılmış bir öğrenme yolu sunar.

İster bir AI geliştiricisi, sistem mimarı, ister yazılım mühendisi olun, bu rehber MCP temellerini ve uygulama stratejilerini öğrenmeniz için kapsamlı bir kaynaktır.

## 🔗 Resmi MCP Kaynakları

- 📘 [MCP Dokümantasyonu](https://modelcontextprotocol.io/) – Detaylı öğreticiler ve kullanıcı kılavuzları  
- 📜 [MCP Spesifikasyonu](https://spec.modelcontextprotocol.io/) – Protokol mimarisi ve teknik referanslar  
- 🧑‍💻 [MCP GitHub Deposu](https://github.com/modelcontextprotocol) – Açık kaynak SDK’lar, araçlar ve kod örnekleri  

## 🧭 Tam MCP Müfredat Yapısı

| Bölüm | Başlık | Açıklama | Bağlantı |
|--|--|--|--|
| 00 | **MCP’ye Giriş** | Model Context Protocol’un genel tanıtımı ve AI iş akışlarındaki önemi, MCP nedir, neden standartlaştırma önemlidir ve pratik kullanım örnekleri ile faydaları | [Giriş](./00-Introduction/README.md) |
| 01 | **Temel Kavramlar** | MCP’nin temel kavramlarının detaylı incelenmesi, istemci-sunucu mimarisi, protokolün ana bileşenleri ve mesajlaşma kalıpları | [Temel Kavramlar](./01-CoreConcepts/README.md) |
| 02 | **MCP’de Güvenlik** | MCP tabanlı sistemlerde güvenlik tehditlerinin tanımlanması, güvenli uygulama teknikleri ve en iyi uygulamalar | [Güvenlik](./02-Security/README.md) |
| 03 | **MCP’ye Başlarken** | Ortam kurulumu ve yapılandırma, temel MCP sunucu ve istemcilerinin oluşturulması, MCP’nin mevcut uygulamalarla entegrasyonu | [Başlarken](./03-GettingStarted/README.md) |
| 3.1 | **İlk Sunucu** | MCP protokolü kullanarak temel bir sunucu kurulumu, sunucu-istemci etkileşiminin anlaşılması ve sunucunun test edilmesi | [İlk Sunucu](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **İlk İstemci** | MCP protokolü kullanarak temel bir istemci kurulumu, istemci-sunucu etkileşiminin anlaşılması ve istemcinin test edilmesi | [İlk İstemci](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLM ile İstemci** | MCP protokolü kullanarak Büyük Dil Modeli (LLM) ile bir istemci kurulumu | [LLM ile İstemci](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Code ile Sunucu Tüketimi** | MCP protokolü kullanarak Visual Studio Code’un sunucuları tüketmesi için ayarlanması | [Visual Studio Code ile Sunucu Tüketimi](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSE ile Sunucu Oluşturma** | SSE, sunucuyu internete açmamıza yardımcı olur. Bu bölümde SSE kullanarak sunucu oluşturmayı öğreneceksiniz | [SSE ile Sunucu Oluşturma](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Akışı** | İstemciler ve MCP sunucuları arasında gerçek zamanlı veri aktarımı için HTTP akışını nasıl uygulayacağınızı öğrenin | [HTTP Akışı](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AI Araç Setini Kullanma** | AI araç seti, AI ve MCP iş akışınızı yönetmenize yardımcı olacak harika bir araçtır. | [AI Araç Setini Kullanma](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Sunucunuzu Test Etme** | Test etmek, geliştirme sürecinin önemli bir parçasıdır. Bu bölümde farklı araçlarla test yapmayı öğreneceksiniz. | [Sunucunuzu Test Etme](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Sunucunuzu Dağıtma** | Yerel geliştirmeden üretime nasıl geçilir? Bu bölüm sunucunuzu geliştirip dağıtmanıza yardımcı olacak. | [Sunucunuzu Dağıtma](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Pratik Uygulama** | Farklı dillerde SDK kullanımı, hata ayıklama, test ve doğrulama, tekrar kullanılabilir prompt şablonları ve iş akışları oluşturma | [Pratik Uygulama](./04-PracticalImplementation/README.md) |
| 05 | **MCP’de İleri Konular** | Çok modlu AI iş akışları ve genişletilebilirlik, güvenli ölçeklendirme stratejileri, MCP’nin kurumsal ekosistemlerde kullanımı | [İleri Konular](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP’nin Azure ile Entegrasyonu** | Azure ile entegrasyonu gösterir | [MCP Azure Entegrasyonu](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Çoklu Modalite** | Görüntüler ve diğer modlar gibi farklı modalitelerle çalışma gösterimi | [Çoklu Modalite](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | MCP ile OAuth2’yi gösteren minimal Spring Boot uygulaması, hem Yetkilendirme hem de Kaynak Sunucusu olarak. Güvenli token verme, korumalı uç noktalar, Azure Container Apps dağıtımı ve API Yönetimi entegrasyonunu gösterir. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Kök Bağlamlar** | Kök bağlamlar hakkında daha fazla bilgi ve nasıl uygulanacağı | [Kök Bağlamlar](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Yönlendirme** | Farklı yönlendirme türlerini öğrenin | [Yönlendirme](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Örnekleme** | Örnekleme ile nasıl çalışılacağını öğrenin | [Örnekleme](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Ölçeklendirme** | MCP sunucularının ölçeklendirilmesi, yatay ve dikey ölçeklendirme stratejileri, kaynak optimizasyonu ve performans ayarı hakkında bilgi | [Ölçeklendirme](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Güvenlik** | MCP Sunucunuzu güvenceye alma, kimlik doğrulama, yetkilendirme ve veri koruma stratejileri | [Güvenlik](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Arama MCP** | Python MCP sunucu ve istemcisi, SerpAPI ile gerçek zamanlı web, haber, ürün araması ve Soru-Cevap entegrasyonu. Çoklu araç orkestrasyonu, dış API entegrasyonu ve sağlam hata yönetimi gösterir | [Web Arama MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Gerçek Zamanlı Akış** | Gerçek zamanlı veri akışı, günümüz veri odaklı dünyasında işletmelerin ve uygulamaların zamanında kararlar alabilmesi için vazgeçilmez hale geldi. | [Gerçek Zamanlı Akış](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Gerçek Zamanlı Web Arama** | MCP’nin gerçek zamanlı web aramayı nasıl dönüştürdüğünü, AI modelleri, arama motorları ve uygulamalar arasında bağlam yönetimini standartlaştırarak nasıl sağladığını öğrenin. | [Gerçek Zamanlı Web Arama](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Topluluk Katkıları** | Kod ve doküman katkısı nasıl yapılır, GitHub üzerinden iş birliği, topluluk odaklı geliştirmeler ve geri bildirim | [Topluluk Katkıları](./06-CommunityContributions/README.md) |
| 07 | **Lições da Adoção Inicial** | Implementações no mundo real e o que funcionou, criação e implantação de soluções baseadas em MCP, tendências e roadmap futuro | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Melhores Práticas para MCP** | Ajuste de desempenho e otimização, design de sistemas MCP tolerantes a falhas, estratégias de teste e resiliência | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Estudos de Caso MCP** | Análises detalhadas das arquiteturas de soluções MCP, modelos de implantação e dicas de integração, diagramas anotados e walkthroughs de projetos | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Otimização de Fluxos de Trabalho em IA: Construindo um Servidor MCP com AI Toolkit** | Workshop prático completo combinando MCP com o AI Toolkit da Microsoft para VS Code. Aprenda a construir aplicações inteligentes que conectam modelos de IA com ferramentas do mundo real através de módulos práticos que cobrem fundamentos, desenvolvimento de servidor customizado e estratégias de implantação em produção. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Projetos de Exemplo

### 🧮 Projetos de Exemplo do Calculador MCP:
<details>
  <summary><strong>Explore Implementações em Código por Linguagem</strong></summary>

  - [Exemplo de Servidor MCP em C#](./03-GettingStarted/samples/csharp/README.md)
  - [Calculadora MCP em Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demonstração MCP em JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Servidor MCP em Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Exemplo MCP em TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Projetos Avançados de Calculadora MCP:
<details>
  <summary><strong>Explore Exemplos Avançados</strong></summary>

  - [Exemplo Avançado em C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Exemplo de App Container em Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Exemplo Avançado em JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementação Complexa em Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Exemplo de Container em TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Pré-requisitos para Aprender MCP

Para aproveitar ao máximo este currículo, você deve ter:

- Conhecimentos básicos em C#, Java ou Python  
- Entendimento do modelo cliente-servidor e APIs  
- (Opcional) Familiaridade com conceitos de machine learning  

## 📚 Guia de Estudo

Um [Guia de Estudo](./study_guide.md) completo está disponível para ajudar você a navegar neste repositório de forma eficiente. O guia inclui:

- Um mapa visual do currículo mostrando todos os tópicos abordados  
- Detalhamento de cada seção do repositório  
- Orientações sobre como usar os projetos de exemplo  
- Caminhos recomendados de aprendizado para diferentes níveis de habilidade  
- Recursos adicionais para complementar sua jornada de aprendizado  

## 🛠️ Como Usar Este Currículo de Forma Eficiente

Cada lição deste guia inclui:

1. Explicações claras dos conceitos MCP  
2. Exemplos de código ao vivo em várias linguagens  
3. Exercícios para construir aplicações MCP reais  
4. Recursos extras para aprendizes avançados  

## 📜 Informações sobre Licença

Este conteúdo está licenciado sob a **MIT License**. Para termos e condições, consulte o [LICENSE](../../LICENSE).

## 🤝 Diretrizes para Contribuição

Este projeto aceita contribuições e sugestões. A maioria das contribuições exige que você concorde com um Contributor License Agreement (CLA) declarando que você tem o direito e realmente concede a nós os direitos de usar sua contribuição. Para mais detalhes, visite <https://cla.opensource.microsoft.com>.

Ao enviar um pull request, um bot CLA determinará automaticamente se você precisa fornecer um CLA e marcará o PR adequadamente (ex.: verificação de status, comentário). Basta seguir as instruções fornecidas pelo bot. Você precisará fazer isso apenas uma vez para todos os repositórios que usam nosso CLA.

Este projeto adotou o [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Para mais informações, veja o [FAQ do Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/) ou entre em contato pelo e-mail [opencode@microsoft.com](mailto:opencode@microsoft.com) para quaisquer dúvidas ou comentários adicionais.

## 🎒 Outros Cursos
Nossa equipe produz outros cursos! Confira:

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

이 프로젝트에는 프로젝트, 제품 또는 서비스의 상표나 로고가 포함될 수 있습니다. Microsoft 상표나 로고의 권한 있는 사용은
[Microsoft의 상표 및 브랜드 가이드라인](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)을 준수해야 합니다.
수정된 버전의 프로젝트에서 Microsoft 상표나 로고를 사용하는 경우 혼동을 일으키거나 Microsoft 후원을 암시해서는 안 됩니다.
타사 상표나 로고 사용은 해당 타사의 정책을 따라야 합니다.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.