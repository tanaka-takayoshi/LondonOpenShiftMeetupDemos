CronJob Example
===

Execute your .NET Core Console application as a OpenShift cronjob.

## How to

1. Replace registry IP and port in cronjob.yaml.

2. Execute commands:
    ```
    $ oc create imagestream cronjobexample
    $ oc create -f cronjob-buildconfig.yaml
    $ oc create -f cronjob.yaml
    ```