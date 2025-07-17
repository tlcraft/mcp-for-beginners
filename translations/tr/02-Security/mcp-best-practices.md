<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:54:20+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "tr"
}
-->
# MCP Güvenlik En İyi Uygulamaları

MCP sunucularıyla çalışırken, verilerinizi, altyapınızı ve kullanıcılarınızı korumak için aşağıdaki güvenlik en iyi uygulamalarını takip edin:

1. **Girdi Doğrulama**: Enjeksiyon saldırılarını ve karışıklık sorunlarını önlemek için girdileri her zaman doğrulayın ve temizleyin.
2. **Erişim Kontrolü**: MCP sunucunuz için ince ayrıntılı izinlerle uygun kimlik doğrulama ve yetkilendirme uygulayın.
3. **Güvenli İletişim**: MCP sunucunuzla tüm iletişimlerde HTTPS/TLS kullanın ve hassas veriler için ek şifreleme eklemeyi düşünün.
4. **Hız Sınırlandırma**: Kötüye kullanımı, DoS saldırılarını önlemek ve kaynak tüketimini yönetmek için hız sınırlandırma uygulayın.
5. **Kayıt Tutma ve İzleme**: MCP sunucunuzu şüpheli faaliyetlere karşı izleyin ve kapsamlı denetim kayıtları oluşturun.
6. **Güvenli Depolama**: Hassas verileri ve kimlik bilgilerini uygun şekilde şifreleyerek koruyun.
7. **Token Yönetimi**: Tüm model girdilerini ve çıktıları doğrulayarak ve temizleyerek token geçişi açıklarını önleyin.
8. **Oturum Yönetimi**: Oturum kaçırma ve sabitleme saldırılarını önlemek için güvenli oturum yönetimi uygulayın.
9. **Araç Çalıştırma İzolasyonu**: Araç çalıştırmalarını izole ortamlarda yaparak ele geçirilme durumunda yan hareketleri engelleyin.
10. **Düzenli Güvenlik Denetimleri**: MCP uygulamalarınızı ve bağımlılıklarını periyodik olarak güvenlik açısından gözden geçirin.
11. **İstem Doğrulama**: İstem enjeksiyonu saldırılarını önlemek için hem giriş hem de çıkış istemlerini tarayın ve filtreleyin.
12. **Kimlik Doğrulama Yetkilendirmesi**: Özel kimlik doğrulama uygulamak yerine yerleşik kimlik sağlayıcıları kullanın.
13. **İzin Kapsamı**: En az ayrıcalık prensiplerine uygun olarak her araç ve kaynak için ayrıntılı izinler uygulayın.
14. **Veri Azaltma**: Risk yüzeyini azaltmak için her işlem için yalnızca gerekli minimum veriyi açığa çıkarın.
15. **Otomatik Güvenlik Açığı Taraması**: MCP sunucularınızı ve bağımlılıklarını düzenli olarak bilinen güvenlik açıklarına karşı tarayın.

## MCP Güvenlik En İyi Uygulamaları İçin Destekleyici Kaynaklar

### Girdi Doğrulama
- [OWASP Girdi Doğrulama Hile Sayfası](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [MCP’de İstem Enjeksiyonunu Önleme](https://modelcontextprotocol.io/docs/guides/security)
- [Azure İçerik Güvenliği Uygulaması](./azure-content-safety-implementation.md)

### Erişim Kontrolü
- [MCP Yetkilendirme Spesifikasyonu](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Sunucularında Microsoft Entra ID Kullanımı](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [MCP için Azure API Yönetimi Yetkilendirme Geçidi](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Güvenli İletişim
- [Taşıma Katmanı Güvenliği (TLS) En İyi Uygulamaları](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Taşıma Güvenliği Kılavuzu](https://modelcontextprotocol.io/docs/concepts/transports)
- [Yapay Zeka İş Yükleri için Uçtan Uca Şifreleme](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Hız Sınırlandırma
- [API Hız Sınırlandırma Modelleri](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Token Bucket Hız Sınırlandırma Uygulaması](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Azure API Yönetiminde Hız Sınırlandırma](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Kayıt Tutma ve İzleme
- [Yapay Zeka Sistemleri için Merkezi Kayıt Tutma](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Denetim Kaydı En İyi Uygulamaları](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Yapay Zeka İş Yükleri için Azure Monitor](https://learn.microsoft.com/azure/azure-monitor/overview)

### Güvenli Depolama
- [Kimlik Bilgileri Depolama için Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Hassas Verilerin Diskte Şifrelenmesi](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Güvenli Token Depolama ve Token Şifreleme](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Token Yönetimi
- [JWT En İyi Uygulamaları (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Güvenlik En İyi Uygulamaları (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Token Doğrulama ve Ömür Yönetimi En İyi Uygulamaları](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Oturum Yönetimi
- [OWASP Oturum Yönetimi Hile Sayfası](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Oturum Yönetimi Kılavuzu](https://modelcontextprotocol.io/docs/guides/security)
- [Güvenli Oturum Tasarım Modelleri](https://learn.microsoft.com/security/engineering/session-security)

### Araç Çalıştırma İzolasyonu
- [Konteyner Güvenliği En İyi Uygulamaları](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Süreç İzolasyonu Uygulaması](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Konteyner Uygulamaları için Kaynak Sınırları](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Düzenli Güvenlik Denetimleri
- [Microsoft Güvenlik Geliştirme Yaşam Döngüsü](https://www.microsoft.com/sdl)
- [OWASP Uygulama Güvenliği Doğrulama Standardı](https://owasp.org/www-project-application-security-verification-standard/)
- [Güvenlik Kod İnceleme Kılavuzu](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### İstem Doğrulama
- [Microsoft İstem Kalkanları](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Yapay Zeka için Azure İçerik Güvenliği](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [İstem Enjeksiyonunu Önleme](https://github.com/microsoft/prompt-shield-js)

### Kimlik Doğrulama Yetkilendirmesi
- [Microsoft Entra ID Entegrasyonu](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [MCP Hizmetleri için OAuth 2.0](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Güvenlik Kontrolleri 2025](./mcp-security-controls-2025.md)

### İzin Kapsamı
- [Güvenli En Az Ayrıcalıklı Erişim](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Rol Tabanlı Erişim Kontrolü (RBAC) Tasarımı](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [MCP’de Araç Bazlı Yetkilendirme](https://modelcontextprotocol.io/docs/guides/best-practices)

### Veri Azaltma
- [Tasarım Yoluyla Veri Koruma](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [Yapay Zeka Veri Gizliliği En İyi Uygulamaları](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Gizliliği Artıran Teknolojilerin Uygulanması](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Otomatik Güvenlik Açığı Taraması
- [GitHub Gelişmiş Güvenlik](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Uygulaması](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Sürekli Güvenlik Doğrulaması](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.