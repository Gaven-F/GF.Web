# 配置文件描述

## Swagger 配置文件

**Node Name:** `SwaggerOptions`

**EX:**

```json
{
  "SwaggerOptions": {
    "Doc": [
      {
        ...,
        "Info": {
          ...
        }
      }
    ],
    "OpenAi": {
      ...
    },
    "UI": {
      ...
    }
  }
}
```

### Docunemt 配置

**Node Name:** `Doc`

| Key           | Type     | Default Value | Remake         |
| :------------ | :------- | :------------ | :------------- |
| Name          | String   | V1            | 文档名称设置   |
| ApiGroupNames | String[] | empty/null    | 该文档分组     |
| Info          | Info     | null          | 该文档其他信息 |

#### Document Info 配置

**Node Name:** `Info`

| Key            | Type   | Default Value | Remake           |
| :------------- | :----- | :------------ | :--------------- |
| AuthorName     | String | null          | 文档作者名称     |
| AuthorUrl      | String | null          | 文档作者首页链接 |
| AuthorEmail    | String | null          | 文档作者电子邮箱 |
|                |        |               |                  |
| LicenseName    | String | null          | 文档许可证名称   |
| LicenseUrl     | String | null          | 文档许可证链接   |
|                |        |               |                  |
| Title          | String | GF.Web        | 文档名称         |
| Version        | String | 0.0.1         | 文档版本号       |
| Description    | String | null          | 文档描述         |
| TermsOfService | String | null          | 文档服务条款     |

### OpenApi 配置

**Node Name:** `OpenAi`

### WebUI 配置

**Node Name:** `UI`
