# AbpVNextZero

## 介绍

基于AbpVNext构建轻量的模块框架，移除官网架构中非必要的功能，并对CI&CD做了进一步的支持，支持docker镜像生成、k8s部署，它是针对的是微服务的快速启动模板。

## 使用

使用rename.ps1，重命名为及的项目和命名空间，如下

1.使用命令行转到当前目录，执行 
```
.\rename.ps1 YouProjectName
```
3.等待执行完毕，会在当前目录中生成新的项目

## CI&CD说明

CI和CD实现了在dev分支上有提交或者请求合并后，构建、推送到镜像本地镜像库中，然后部署到k8s集群。

实现步骤为
1. 使用宿主机的`dotnet`命令编译程序
2. docker构建并推送镜像
3. 拉取gitlab的配置的文件环境变量生成k8s集群连接配置
4. 使用`envsubst`对`k8s/deployment.yaml`中的环境变量进行替换，生成完成的部署yaml
5. `kubectl`应用yaml文件