import http from 'k6/http';
import {sleep} from 'k6';
export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    vus: 1000,
    duration: '15s'
};

export default () => {
    http.get('https://www.boredapi.com/api/activity')
};