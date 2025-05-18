<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:24:23+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "pt"
}
-->
# Práticas de Segurança

Adotar o Protocolo de Contexto de Modelo (MCP) traz capacidades novas e poderosas para aplicativos impulsionados por IA, mas também introduz desafios de segurança únicos que vão além dos riscos tradicionais de software. Além de preocupações estabelecidas como codificação segura, privilégio mínimo e segurança da cadeia de suprimentos, MCP e cargas de trabalho de IA enfrentam novas ameaças, como injeção de prompt, envenenamento de ferramentas e modificação dinâmica de ferramentas. Esses riscos podem levar à exfiltração de dados, violações de privacidade e comportamento indesejado do sistema se não forem geridos adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompt e vulnerabilidades na cadeia de suprimentos — e fornece controles acionáveis e práticas recomendadas para mitigá-los. Você também aprenderá a aproveitar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security para fortalecer sua implementação do MCP. Ao entender e aplicar esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos de segurança únicos introduzidos pelo Protocolo de Contexto de Modelo (MCP), incluindo injeção de prompt, envenenamento de ferramentas, permissões excessivas e vulnerabilidades na cadeia de suprimentos.
- Descrever e aplicar controles eficazes de mitigação para riscos de segurança do MCP, como autenticação robusta, privilégio mínimo, gerenciamento seguro de tokens e verificação da cadeia de suprimentos.
- Entender e aproveitar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security para proteger cargas de trabalho do MCP e IA.
- Reconhecer a importância de validar metadados de ferramentas, monitorar mudanças dinâmicas e defender-se contra ataques de injeção indireta de prompt.
- Integrar práticas de segurança estabelecidas — como codificação segura, fortalecimento de servidores e arquitetura de confiança zero — na sua implementação do MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controles de segurança do MCP

Qualquer sistema que tenha acesso a recursos importantes tem desafios de segurança implícitos. Os desafios de segurança geralmente podem ser abordados por meio da aplicação correta de controles e conceitos de segurança fundamentais. Como o MCP é recém-definido, a especificação está mudando rapidamente à medida que o protocolo evolui. Eventualmente, os controles de segurança dentro dele amadurecerão, permitindo uma melhor integração com arquiteturas de segurança empresariais e práticas recomendadas estabelecidas.

Pesquisas publicadas no [Relatório de Defesa Digital da Microsoft](https://aka.ms/mddr) afirmam que 98% das violações relatadas seriam evitadas por uma higiene de segurança robusta, e a melhor proteção contra qualquer tipo de violação é acertar sua higiene de segurança básica, práticas recomendadas de codificação segura e segurança da cadeia de suprimentos — aquelas práticas testadas e comprovadas que já conhecemos ainda fazem o maior impacto na redução do risco de segurança.

Vamos ver algumas das maneiras pelas quais você pode começar a abordar os riscos de segurança ao adotar o MCP.

# Autenticação de servidor MCP (se sua implementação do MCP foi antes de 26 de abril de 2025)

> **Nota:** As informações a seguir são corretas a partir de 26 de abril de 2025. O protocolo MCP está em constante evolução, e implementações futuras podem introduzir novos padrões e controles de autenticação. Para as atualizações e orientações mais recentes, consulte sempre a [Especificação do MCP](https://spec.modelcontextprotocol.io/) e o repositório oficial [MCP GitHub](https://github.com/modelcontextprotocol).

### Declaração do problema 
A especificação original do MCP assumia que os desenvolvedores escreveriam seu próprio servidor de autenticação. Isso exigia conhecimento de OAuth e restrições de segurança relacionadas. Servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerenciando a autenticação de usuários necessária diretamente, em vez de delegá-la a um serviço externo como o Microsoft Entra ID. A partir de 26 de abril de 2025, uma atualização na especificação do MCP permite que servidores MCP deleguem a autenticação de usuários a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e controles de acesso aplicados incorretamente.
- Roubo de token OAuth no servidor MCP local. Se roubado, o token pode ser usado para personificar o servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth é destinado.

### Controles de mitigação
- **Revisar e Fortalecer a Lógica de Autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes pretendidos possam acessar recursos sensíveis. Para orientação prática, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Impor Práticas Seguras de Token:** Siga [práticas recomendadas da Microsoft para validação e duração de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para prevenir o uso indevido de tokens de acesso e reduzir o risco de repetição ou roubo de tokens.
- **Proteger o Armazenamento de Tokens:** Sempre armazene tokens de forma segura e use criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema
Servidores MCP podem ter recebido permissões excessivas para o serviço/recurso que estão acessando. Por exemplo, um servidor MCP que faz parte de um aplicativo de vendas de IA conectado a um repositório de dados empresariais deve ter acesso limitado aos dados de vendas e não permitido acessar todos os arquivos no repositório. Referindo-se ao princípio do privilégio mínimo (um dos princípios de segurança mais antigos), nenhum recurso deve ter permissões em excesso ao que é necessário para executar as tarefas para as quais foi destinado. A IA apresenta um desafio aumentado nesse espaço porque, para permitir que seja flexível, pode ser desafiador definir as permissões exatas necessárias.

### Riscos 
- Conceder permissões excessivas pode permitir a exfiltração ou alteração de dados que o servidor MCP não foi destinado a poder acessar. Isso também pode ser um problema de privacidade se os dados forem informações pessoalmente identificáveis (PII).

### Controles de mitigação
- **Aplicar o Princípio do Privilégio Mínimo:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para executar suas tarefas requeridas. Revise e atualize regularmente essas permissões para garantir que não excedam o necessário. Para orientação detalhada, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Controle de Acesso Baseado em Funções (RBAC):** Atribua funções ao servidor MCP que sejam estritamente limitadas a recursos e ações específicos, evitando permissões amplas ou desnecessárias.
- **Monitorar e Auditar Permissões:** Monitore continuamente o uso de permissões e audite logs de acesso para detectar e remediar privilégios excessivos ou não utilizados prontamente.

# Ataques de injeção indireta de prompt

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem introduzir riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompt**: Atacantes incorporam instruções maliciosas em prompts ou conteúdo externo, fazendo com que o sistema de IA execute ações não intencionais ou vaze dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas**: Atacantes manipulam metadados de ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente contornando controles de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção de Prompt entre Domínios**: Instruções maliciosas são incorporadas em documentos, páginas da web ou e-mails, que são então processados pela IA, levando a vazamento ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls)**: Definições de ferramentas podem ser alteradas após a aprovação do usuário, introduzindo novos comportamentos maliciosos sem o conhecimento do usuário.

Essas vulnerabilidades destacam a necessidade de validação robusta, monitoramento e controles de segurança ao integrar servidores e ferramentas MCP em seu ambiente. Para um mergulho mais profundo, veja as referências vinculadas acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.pt.png)

**Injeção Indireta de Prompt** (também conhecida como injeção de prompt entre domínios ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo aqueles que usam o Protocolo de Contexto de Modelo (MCP). Nesse ataque, instruções maliciosas são ocultadas dentro de conteúdo externo — como documentos, páginas da web ou e-mails. Quando o sistema de IA processa esse conteúdo, pode interpretar as instruções incorporadas como comandos legítimos do usuário, resultando em ações não intencionais como vazamento de dados, geração de conteúdo prejudicial ou manipulação de interações do usuário. Para uma explicação detalhada e exemplos do mundo real, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa desse ataque é o **Envenenamento de Ferramentas**. Aqui, atacantes injetam instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros de ferramentas). Como modelos de linguagem grandes (LLMs) dependem desses metadados para decidir quais ferramentas invocar, descrições comprometidas podem enganar o modelo para executar chamadas de ferramentas não autorizadas ou contornar controles de segurança. Essas manipulações geralmente são invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco é aumentado em ambientes de servidores MCP hospedados, onde definições de ferramentas podem ser atualizadas após a aprovação do usuário — um cenário às vezes referido como um "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nesses casos, uma ferramenta que anteriormente era segura pode mais tarde ser modificada para executar ações maliciosas, como exfiltrar dados ou alterar o comportamento do sistema, sem o conhecimento do usuário. Para mais informações sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.pt.png)

## Riscos
Ações não intencionais de IA apresentam uma variedade de riscos de segurança que incluem exfiltração de dados e violações de privacidade.

### Controles de mitigação
### Usando escudos de prompt para proteger contra ataques de Injeção Indireta de Prompt
-----------------------------------------------------------------------------

**Escudos de Prompt de IA** são uma solução desenvolvida pela Microsoft para defender contra ataques de injeção de prompt, tanto diretos quanto indiretos. Eles ajudam através de:

1. **Detecção e Filtragem**: Os Escudos de Prompt usam algoritmos avançados de aprendizado de máquina e processamento de linguagem natural para detectar e filtrar instruções maliciosas incorporadas em conteúdo externo, como documentos, páginas da web ou e-mails.
    
2. **Spotlighting**: Esta técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de forma que o torne mais relevante para o modelo, o Spotlighting garante que a IA possa identificar melhor e ignorar instruções maliciosas.
    
3. **Delimitadores e Datamarking**: Incluir delimitadores na mensagem do sistema delineia explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar entradas de usuários de conteúdo externo potencialmente prejudicial. O Datamarking estende esse conceito usando marcadores especiais para destacar os limites de dados confiáveis e não confiáveis.
    
4. **Monitoramento e Atualizações Contínuas**: A Microsoft monitora continuamente e atualiza os Escudos de Prompt para enfrentar ameaças novas e em evolução. Essa abordagem proativa garante que as defesas permaneçam eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Os Escudos de Prompt fazem parte do conjunto mais amplo de segurança de conteúdo do Azure AI, que fornece ferramentas adicionais para detectar tentativas de jailbreak, conteúdo prejudicial e outros riscos de segurança em aplicativos de IA.

Você pode ler mais sobre escudos de prompt de IA na [documentação dos Escudos de Prompt](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.pt.png)

### Segurança da cadeia de suprimentos

A segurança da cadeia de suprimentos continua sendo fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes de código tradicionais, você deve agora verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos de base, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um deles pode introduzir vulnerabilidades ou riscos se não forem geridos adequadamente.

**Práticas de segurança da cadeia de suprimentos para IA e MCP:**
- **Verifique todos os componentes antes da integração:** Isso inclui não apenas bibliotecas de código aberto, mas também modelos de IA, fontes de dados e APIs externas. Sempre verifique a proveniência, licenciamento e vulnerabilidades conhecidas.
- **Mantenha pipelines de implantação seguros:** Use pipelines de CI/CD automatizados com varredura de segurança integrada para detectar problemas cedo. Garanta que apenas artefatos confiáveis sejam implantados em produção.
- **Monitore e audite continuamente:** Implemente monitoramento contínuo para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques à cadeia de suprimentos.
- **Aplique privilégio mínimo e controles de acesso:** Restrinja o acesso a modelos, dados e serviços ao necessário para o funcionamento do seu servidor MCP.
- **Responda rapidamente às ameaças:** Tenha um processo em vigor para corrigir ou substituir componentes comprometidos, e para girar segredos ou credenciais se uma violação for detectada.

[GitHub Advanced Security](https://github.com/security/advanced-security) fornece recursos como varredura de segredos, varredura de dependências e análise CodeQL. Essas ferramentas se integram com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades em componentes de código e da cadeia de suprimentos de IA.

A Microsoft também implementa extensas práticas de segurança da cadeia de suprimentos internamente para todos os produtos. Saiba mais em [A Jornada para Proteger a Cadeia de Suprimentos de Software na Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Práticas de segurança estabelecidas que elevarão a postura de segurança da sua implementação do MCP

Qualquer implementação do MCP herda a postura de segurança existente do ambiente da sua organização em que é construída, portanto, ao considerar a segurança do MCP como um componente dos seus sistemas de IA gerais, é recomendado que você procure elevar sua postura de segurança existente geral. Os seguintes controles de segurança estabelecidos são especialmente relevantes:

- Práticas recomendadas de codificação segura em seu aplicativo de IA - proteja contra [o OWASP Top 10](https://owasp.org/www-project-top-ten/), o [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras de ponta a ponta entre todos os componentes do aplicativo, etc.
- Fortalecimento de servidores - use MFA sempre que possível, mantenha as atualizações de patches em dia, integre o servidor com um provedor de identidade de terceiros para acesso, etc.
- Mantenha dispositivos, infraestrutura e aplicativos atualizados com patches
- Monitoramento de segurança - implementando registro e monitoramento de um aplicativo de IA (incluindo o cliente/servidores MCP) e enviando esses registros para um SIEM central para detectar atividades anômalas
- Arquitetura de confiança zero - isolando componentes por meio de controles de rede e identidade de maneira lógica para minimizar o movimento lateral se um aplicativo de IA for comprometido.

# Conclusões Principais

- Os fundamentos de segurança continuam críticos: Codificação segura, privilégio mínimo, verificação da cadeia de suprimentos e monitoramento contínuo são essenciais para cargas de trabalho do MCP e IA.
- MCP introduz novos riscos — como injeção de prompt, envenenamento de ferramentas e permissões excessivas — que exigem controles tanto tradicionais quanto específicos de IA.
- Use práticas robustas de autenticação, autorização e gerenciamento de tokens, aproveitando provedores de identidade externos como Microsoft Entra ID sempre que possível.
- Proteja contra injeção indireta de prompt e envenenamento de ferramentas validando metadados de ferramentas, monitorando mudanças dinâmicas e usando soluções como Microsoft Prompt Shields.
- Trate todos os componentes em sua cadeia de suprimentos de IA — incluindo modelos, embeddings e provedores de contexto — com o mesmo rigor que as dependências de código.
- Mantenha-se atualizado com as especificações em evolução do MCP e contribua para a comunidade para ajudar a moldar padrões seguros.

# Recursos Adicionais

- [Relatório de Defesa Digital da Microsoft](https://aka.ms/mddr)
- [Especificação do MCP](https://spec.modelcontextprotocol.io
- [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [Segurança Avançada do GitHub](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [A Jornada para Proteger a Cadeia de Suprimentos de Software na Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acesso Seguro com Menos Privilégios (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Melhores Práticas para Validação e Tempo de Vida de Tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Armazenamento Seguro de Tokens e Criptografe Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como Gateway de Autenticação para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Usando o Microsoft Entra ID para Autenticar com Servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Próximo

Próximo: [Capítulo 3: Introdução](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.