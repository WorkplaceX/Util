# Proxy
Test for example Angular application client running on a different time zone than server. When changing system time zone both client and server time zones are changed. Mittigate it by opening a proxy.

If certificate errors occur use
```
"C:\Program Files\Google\Chrome\Application\chrome.exe" --ignore-certificate-errors

# package.json
"start": "ng serve --host 0.0.0.0",
```

![a](01%20Proxy.png)

![a](02%20Proxy.png)

![a](03%20Proxy.png)

![a](04%20Proxy.png)
