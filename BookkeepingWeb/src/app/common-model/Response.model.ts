export class ResponseModel {
    isError: boolean;
    message: string;
    responseException: string;
    result: any;
    statusCode: number;
    constructor() {
        this.isError = false,
        this.message = '',
        this.statusCode = 0
        this.responseException = '',
        this.result = [];
    }
}
