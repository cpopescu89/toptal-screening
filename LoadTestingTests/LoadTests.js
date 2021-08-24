import http from 'k6/http';
export let options = {
    insecureSkipTLSVerify: true,
    thresholds: {
        http_req_duration: ['p(90)<600']
    },
    scenarios: {
        calls: {
            executor: 'per-vu-iterations',
    vus: 1000,
            iterations: '1',
            maxDuration: '15s',
        }
    }

};

export default () => {
    http.get('https://www.boredapi.com/api/activity')
};