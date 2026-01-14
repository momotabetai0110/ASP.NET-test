# ASP.NET Core Web API 学習ガイド

このドキュメントでは、ASP.NET Core Web APIの基本的な環境構築からAPI実装までの手順を説明します。

## 目次

1. [環境構築](#環境構築)
2. [フレームワークの説明](#フレームワークの説明)
3. [API実装の手順](#api実装の手順)

---

## 環境構築

### 必要なもの

- .NET SDK（.NET 10.0以上）
- Visual Studio Code または Visual Studio
- C# Dev Kit（VS Codeを使用する場合）

### 手順

#### 1. .NET SDKのインストール確認

```bash
dotnet --version
```

バージョンが表示されれば、.NET SDKはインストール済みです。
表示されない場合は、[.NET公式サイト](https://dotnet.microsoft.com/download)からダウンロードしてインストールしてください。

#### 2. ASP.NET Core Web APIプロジェクトの作成

新しいディレクトリに移動して、プロジェクトを作成します：

```bash
# プロジェクトを作成したいディレクトリに移動
cd 任意のディレクトリパス

# ASP.NET Core Web APIプロジェクトを作成
dotnet new webapi -n WebApiLearning -o WebApiLearning
```

#### 3. プロジェクトディレクトリに移動

```bash
cd WebApiLearning
```

#### 4. プロジェクトの実行

```bash
dotnet run
```

実行が成功すると、以下のようなメッセージが表示されます：

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5287
```

ブラウザで `http://localhost:5287` にアクセスして、アプリケーションが起動していることを確認できます。

#### 5. プロジェクトの停止

アプリケーションを停止するには、ターミナルで `Ctrl + C` を押します。

---

## フレームワークの説明

### ASP.NET Coreとは

**ASP.NET Core**は、Microsoftが開発したクロスプラットフォーム対応のWebアプリケーションフレームワークです。

#### 主な特徴

- **クロスプラットフォーム**: Windows、macOS、Linuxで動作
- **高性能**: 高速なHTTPリクエスト処理
- **モダンなAPI**: RESTful APIの構築に最適
- **依存性注入**: 組み込みのDIコンテナ
- **ミドルウェアパイプライン**: 柔軟なリクエスト処理

### プロジェクト構造

```
WebApiLearning/
├── Program.cs              # メインプログラムファイル（エンドポイント定義）
├── WebApiLearning.csproj   # プロジェクト設定ファイル
├── appsettings.json        # アプリケーション設定ファイル
├── Properties/
│   └── launchSettings.json # 起動設定ファイル
└── WebApiLearning.http     # APIテスト用ファイル
```

### 重要な概念

#### Minimal API

ASP.NET Core 6以降では、**Minimal API**というシンプルなAPI構築方法が導入されました。
従来のコントローラーベースのアプローチよりも、より少ないコードでAPIを構築できます。

```csharp
// Minimal APIの例
app.MapGet("/api/hello", () => "Hello World");
```

#### エンドポイント

エンドポイントは、特定のURLパスとHTTPメソッド（GET、POST、PUT、DELETEなど）の組み合わせです。

- **GET**: データの取得
- **POST**: データの作成
- **PUT**: データの更新
- **DELETE**: データの削除

---

## API実装の手順

ここでは、シンプルな「Hello」APIを実装する手順を説明します。

### ステップ1: Program.csファイルを開く

プロジェクトのルートディレクトリにある `Program.cs` ファイルを開きます。

### ステップ2: 基本的な構造を理解する

`Program.cs`の基本的な構造は以下の通りです：

```csharp
// 1. Webアプリケーションビルダーを作成
var builder = WebApplication.CreateBuilder(args);

// 2. サービスを追加（必要に応じて）
builder.Services.AddOpenApi();

// 3. アプリケーションをビルド
var app = builder.Build();

// 4. ミドルウェアの設定
app.UseHttpsRedirection();

// 5. エンドポイントの定義
app.MapGet("/api/hello", () => {
    return Results.Ok(new { message = "Hello World" });
});

// 6. アプリケーションを起動
app.Run();
```

### ステップ3: Hello APIエンドポイントを追加

`app.UseHttpsRedirection();` の後に、以下のコードを追加します：

```csharp
// GET エンドポイント: /api/hello
app.MapGet("/api/hello", () =>
{
    return Results.Ok(new { message = "こんにちは！ASP.NET Core Web APIへようこそ！" });
})
.WithName("GetHello")
.WithDescription("簡単な挨拶メッセージを返します");
```

#### コードの説明

- **`app.MapGet()`**: GETリクエスト用のエンドポイントを定義
- **`"/api/hello"`**: エンドポイントのURLパス
- **`() => { ... }`**: リクエストが来たときに実行される処理（ラムダ式）
- **`Results.Ok()`**: HTTP 200 OKステータスコードとJSONレスポンスを返す
- **`.WithName()`**: エンドポイントに名前を付ける（OpenAPIドキュメント用）
- **`.WithDescription()`**: エンドポイントの説明を追加（OpenAPIドキュメント用）

### ステップ4: アプリケーションを実行

```bash
dotnet run
```

### ステップ5: APIをテストする

アプリケーションが起動したら、以下のいずれかの方法でAPIをテストできます：

#### 方法1: ブラウザでアクセス

ブラウザで以下のURLにアクセス：
```
http://localhost:5287/api/hello
```

#### 方法2: curlコマンドを使用

```bash
curl http://localhost:5287/api/hello
```

#### 方法3: .httpファイルを使用（VS Code）

`WebApiLearning.http` ファイルに以下を追加：

```http
GET http://localhost:5287/api/hello
Accept: application/json
```

VS Codeで「Send Request」ボタンをクリックします。

### 期待される結果

APIが正常に動作している場合、以下のようなJSONレスポンスが返されます：

```json
{
  "message": "こんにちは！ASP.NET Core Web APIへようこそ！"
}
```

### 完成したコード例

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Hello APIエンドポイント
app.MapGet("/api/hello", () =>
{
    return Results.Ok(new { message = "こんにちは！ASP.NET Core Web APIへようこそ！" });
})
.WithName("GetHello")
.WithDescription("簡単な挨拶メッセージを返します");

app.Run();
```

---

## 次のステップ

Hello APIが動作することを確認したら、以下のトピックに進むことができます：

1. **パラメータを受け取るAPI**: `/api/hello/{name}` のようにURLパスから値を取得
2. **POSTリクエスト**: データを受け取って処理するAPI
3. **エラーハンドリング**: バリデーションやエラー処理
4. **データベース連携**: Entity Framework Coreを使用したデータ永続化
5. **認証・認可**: JWTトークンを使用したセキュリティ

---

## 参考リソース

- [ASP.NET Core公式ドキュメント](https://learn.microsoft.com/aspnet/core/)
- [.NET公式サイト](https://dotnet.microsoft.com/)
- [Minimal APIの詳細](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)

---

## トラブルシューティング

### ポートが既に使用されている場合

別のポートで実行するには、`launchSettings.json`のポート番号を変更するか、以下のコマンドを使用：

```bash
dotnet run --urls "http://localhost:5000"
```

### HTTPSリダイレクトの警告が出る場合

HTTPのみで実行する場合は、`Program.cs`でHTTPSリダイレクトを条件付きで有効化するか、`launchSettings.json`でHTTPSポートを設定してください。

---

**作成日**: 2026年1月
**対象バージョン**: .NET 10.0, ASP.NET Core 10.0
