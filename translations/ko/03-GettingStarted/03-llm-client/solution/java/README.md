<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:22:59+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "ko"
}
-->
# Calculator LLM Client

LangChain4j를 사용해 MCP(Model Context Protocol) 계산기 서비스와 GitHub Models 통합을 연결하는 방법을 보여주는 Java 애플리케이션입니다.

## 사전 준비 사항

- Java 21 이상
- Maven 3.6+ (또는 포함된 Maven 래퍼 사용)
- GitHub Models에 접근 권한이 있는 GitHub 계정
- `http://localhost:8080`에서 실행 중인 MCP 계산기 서비스

## GitHub 토큰 받기

이 애플리케이션은 GitHub Models를 사용하므로 GitHub 개인 액세스 토큰이 필요합니다. 토큰을 받으려면 다음 단계를 따르세요:

### 1. GitHub Models 접속
1. [GitHub Models](https://github.com/marketplace/models)로 이동
2. GitHub 계정으로 로그인
3. 아직 요청하지 않았다면 GitHub Models 접근 권한 요청

### 2. 개인 액세스 토큰 생성
1. [GitHub 설정 → 개발자 설정 → 개인 액세스 토큰 → 토큰(클래식)](https://github.com/settings/tokens)으로 이동
2. "새 토큰 생성" → "새 토큰 생성(클래식)" 클릭
3. 토큰에 설명이 잘 되는 이름 지정(예: "MCP Calculator Client")
4. 필요에 따라 만료 기간 설정
5. 다음 권한 선택:
   - `repo` (비공개 저장소 접근 시)
   - `user:email`
6. "토큰 생성" 클릭
7. **중요**: 토큰은 생성 직후 복사하세요 - 다시 볼 수 없습니다!

### 3. 환경 변수 설정

#### Windows (명령 프롬프트):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## 설정 및 설치

1. **프로젝트 디렉터리 복제 또는 이동**

2. **의존성 설치**:
   ```cmd
   mvnw clean install
   ```
   또는 Maven이 전역 설치되어 있다면:
   ```cmd
   mvn clean install
   ```

3. **환경 변수 설정** ("GitHub 토큰 받기" 섹션 참고)

4. **MCP 계산기 서비스 시작**:
   1장의 MCP 계산기 서비스가 `http://localhost:8080/sse`에서 실행 중인지 확인하세요. 클라이언트 실행 전에 반드시 실행되어야 합니다.

## 애플리케이션 실행

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 애플리케이션 기능

이 애플리케이션은 계산기 서비스와 다음 세 가지 주요 상호작용을 시연합니다:

1. **덧셈**: 24.5와 17.3의 합 계산
2. **제곱근**: 144의 제곱근 계산
3. **도움말**: 사용 가능한 계산기 함수 표시

## 예상 출력

성공적으로 실행되면 다음과 유사한 출력이 나타납니다:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## 문제 해결

### 자주 발생하는 문제

1. **"GITHUB_TOKEN 환경 변수가 설정되지 않음"**
   - `GITHUB_TOKEN`이 제대로 설정되었는지 확인하세요.  
   ` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean

### 디버깅

디버그 로그를 활성화하려면 실행 시 다음 JVM 인수를 추가하세요:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 구성

애플리케이션 구성 내용:
- `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`를 사용하는 GitHub Models
- 요청 타임아웃 60초 설정
- 디버깅을 위한 요청/응답 로깅 활성화

## 의존성

이 프로젝트에서 사용되는 주요 의존성:
- **LangChain4j**: AI 통합 및 도구 관리용
- **LangChain4j MCP**: Model Context Protocol 지원용
- **LangChain4j GitHub Models**: GitHub Models 통합용
- **Spring Boot**: 애플리케이션 프레임워크 및 의존성 주입용

## 라이선스

이 프로젝트는 Apache License 2.0 하에 라이선스가 부여되어 있습니다. 자세한 내용은 [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) 파일을 참고하세요.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.