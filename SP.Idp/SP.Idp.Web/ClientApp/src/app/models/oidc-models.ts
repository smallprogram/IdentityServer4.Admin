import { String, StringBuilder } from 'typescript-string-operations';

class loginInputModel {
    userName: string;
    password: string;
    rememberLogin: boolean;
    returnUrl: string;
}
class loginViewModel extends loginInputModel {
    allowRememberLogin: boolean = true;
    enableLocalLogin: boolean = true;
    externalProviders: Array<externalProvider> = [];
    visibleExternalProviders: Array<externalProvider> = this.externalProviders.filter(x => !String.IsNullOrWhiteSpace(x.dispalyName));
    isExternalLoginOnly: boolean = this.enableLocalLogin == false && this.externalProviders.length == 1;
    externalLoginScheme: string = this.isExternalLoginOnly ? this.externalProviders[0].AuthenticationScheme : null;
}


class externalProvider {
    dispalyName: string;
    AuthenticationScheme: string;
}