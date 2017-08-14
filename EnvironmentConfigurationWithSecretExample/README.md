Environment & Configuration with Secrete examples
===



## How to

1. Edit values of secretkey and secretvalue as you like. Please note, usually this file should not be managed under git repository.
2. Create a secret.
   
   ```
   $ oc create -f secret.yaml
   ```
3. Create an app.
   
   ```
   $ oc new-app dotnet-20-rhel7:latest~https://github.com/tanaka-takayoshi/LondonOpenShiftMeetupDemos.git#dev --name=configexample --context-dir=EnvironmentConfigurationWithSecretExample
   ```
4. Edit deploymentconfig to add environment variables from the secret.
   
   ```
   $ oc edit 
   //like below
    spec:
      containers:
        - name: configexample
          env:
            - name: MYOPTION__SECRETKEY
              valueFrom:
                secretKeyRef:
                  name: mysecrets
                  key: secretkey
            - name: MYOPTION__SECRETVALUE
              valueFrom:
                secretKeyRef:
                  name: mysecrets
                  key: secretvalue
   ```
5. Specify environment.
   
   ```
   $ oc set env dc/configexample --overwrite ASPNETCORE_ENVIRONMENT=Development
   ```