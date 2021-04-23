# Install SSL
Install SSL from Namecheap with IIS on Azure

## Create Certificate Request with IIS
![CertificateRequestDomain.png](CertificateRequestDomain.png)

## Bit Length
![CertificateRequestDomainBitLength.png](CertificateRequestDomainBitLength.png)

## Location of Certificate Request
For debug only. Contains request private key

Start > run > mmc > File > Add/Remove Snap-in... > Certificates > Computer account
![](CertificateRequest.png)

## Domain Control Validation
Use DCV Method: Email

## Namecheap
![Namecheap.png](Namecheap.png)
![NamecheapStep2.png](NamecheapStep2.png)

## Complete Certificate Request
Both file types (*.cer) or (*.crt) can be imported!
![](CompleteCertificateRequest.png)

## Access Denied Error
Access Denied. (Exception from HRESULT: 0x80070005 (E_ACCESSDENIED))
Happens if certificate is already installed. Remove all certificates from IIS and try again.

![](Error.png)

## Export to pxf file
![CerToPfx.png](CerToPfx.png)

