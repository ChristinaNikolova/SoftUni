function solve(httpObj) {
    const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const validUriRegex = new RegExp(new RegExp(/^[a-zA-Z0-9.]+$|^\*$/gm));
    const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const validMessageRegex = new RegExp(/^[^<>\\&'"]*$/gm);

    if (!httpObj.hasOwnProperty('method') || !validMethods.includes(httpObj.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!httpObj.hasOwnProperty('uri') || !httpObj.uri.match(validUriRegex)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!httpObj.hasOwnProperty('version') || !validVersions.includes(httpObj.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (!httpObj.hasOwnProperty('message') || !httpObj.message.match(validMessageRegex)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return httpObj;
}

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));

console.log(solve({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
}));

console.log(solve({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
}));