
# This test is using the K6 tool to simulate 1000 users accessing the API endpoint of boredapi

## By using only one user, the following results where obtained:
- http_req_duration..............: avg=118.39ms min=115.69ms med=117.49ms max=140.09ms

Scenarios: (100.00%) 1 scenario, 1 max VUs, 40s max duration (incl. graceful stop):
           * default: Up to 1 looping VUs for 10s over 1 stages (gracefulRampDown: 30s, gracefulStop: 30s)\
        
running (10.0s), 0/1 VUs, 82 complete and 0 interrupted iterations
default ✓ [======================================] 0/1 VUs  10s

     data_received..................: 47 kB  4.7 kB/s
     data_sent......................: 9.9 kB 984 B/s
     http_req_blocked...............: avg=3.19ms   min=0s       med=0s       max=261.94ms p(90)=0s       p(95)=0s
     http_req_connecting............: avg=1.35ms   min=0s       med=0s       max=111.4ms  p(90)=0s       p(95)=0s
     http_req_duration..............: avg=118.39ms min=115.69ms med=117.49ms max=140.09ms p(90)=120.34ms p(95)=122.91ms
       { expected_response:true }...: avg=118.39ms min=115.69ms med=117.49ms max=140.09ms p(90)=120.34ms p(95)=122.91ms
     http_req_failed................: 0.00%  ✓ 0        ✗ 82
     http_req_receiving.............: avg=126.36µs min=0s       med=0s       max=1.03ms   p(90)=662.01µs p(95)=997.98µs
     http_req_sending...............: avg=24.69µs  min=0s       med=0s       max=507.4µs  p(90)=97.58µs  p(95)=145.11µs
     http_req_tls_handshaking.......: avg=1.43ms   min=0s       med=0s       max=117.49ms p(90)=0s       p(95)=0s
     http_req_waiting...............: avg=118.24ms min=115.64ms med=117.35ms max=140.09ms p(90)=120.34ms p(95)=122.55ms
     http_reqs......................: 82     8.184172/s
     iteration_duration.............: avg=122.08ms min=115.88ms med=118ms    max=381.12ms p(90)=121.43ms p(95)=125.26ms
     iterations.....................: 82     8.184172/s
     vus............................: 1      min=1      max=1
     vus_max........................: 1      min=1      max=1




## By using 1000 users over a 15seconds periond, the following results where obtained
- http_req_duration..............: avg=14.77s   min=635.44ms med=14.93s   max=20.21s p(90)=19.12s   p(95)=19.46s




running (23.9s), 0000/1000 VUs, 1000 complete and 0 interrupted iterations
default ✓ [======================================] 1000 VUs  23.8s/15s  1000/1000 shared iters

     data_received..................: 5.1 MB 213 kB/s
     data_sent......................: 466 kB 20 kB/s
     http_req_blocked...............: avg=2.22s    min=572.4ms  med=2.84s    max=8.23s    p(90)=3.61s    p(95)=3.86s
     http_req_connecting............: avg=281.27ms min=129.6ms  med=299.02ms max=354.72ms p(90)=342.73ms p(95)=348.12ms
     http_req_duration..............: avg=16.45s   min=259.49ms med=16.83s   max=20.1s    p(90)=19.12s   p(95)=19.17s
       { expected_response:true }...: avg=16.45s   min=259.49ms med=16.83s   max=20.1s    p(90)=19.12s   p(95)=19.17s
     http_req_failed................: 0.00%  ✓ 0         ✗ 1000
     http_req_receiving.............: avg=137.97µs min=0s       med=0s       max=1.25ms   p(90)=647.9µs  p(95)=930µs
     http_req_sending...............: avg=49.45µs  min=0s       med=0s       max=1.03ms   p(90)=114.02µs p(95)=508.8µs
     http_req_tls_handshaking.......: avg=1.89s    min=261.29ms med=2.53s    max=7.94s    p(90)=3.26s    p(95)=3.53s
     http_req_waiting...............: avg=16.45s   min=259.49ms med=16.83s   max=20.1s    p(90)=19.12s   p(95)=19.17s
     http_reqs......................: 1000   41.928507/s
     iteration_duration.............: avg=18.68s   min=832.5ms  med=18.82s   max=23.84s   p(90)=22.77s   p(95)=23.73s
     iterations.....................: 1000   41.928507/s
     vus............................: 81     min=81      max=998
     vus_max........................: 1000   min=1000    max=1000



So we can clearly see that using 1000 users this api is struggling to return results, but the site still stands
> Note:
A very good response time (according to the latest trends) would be around 220ms
On average, the servers return a response in around 530ms, so that would still make it good
What is over 850ms it's considered bad, so trying to make it better would be great

Table from above: 

Entry | Explanation |
-- | --|
http_reqs | How many HTTP requests has k6 generated, in total. |
http_req_blocked | Time spent blocked (waiting for a free TCP connection slot) before initiating the request. float |
http_req_connecting	| Time spent establishing TCP connection to the remote host. float
http_req_tls_handshaking |	Time spent handshaking TLS session with remote host
http_req_sending | Time spent sending data to the remote host. float
http_req_waiting | Time spent waiting for response from remote host (a.k.a. \"time to first byte\", or \"TTFB\"). float
http_req_receiving | Time spent receiving response data from the remote host. float
http_req_duration | Total time for the request. It's equal to http_req_sending + http_req_waiting + http_req_receiving (i.e. how long did the remote server take to process the request and respond, without the initial DNS lookup/connection times). float
http_req_failed  | The rate of failed requests according to setResponseCallback.
vus	| Current number of active virtual users
vus_max	| Max possible number of virtual users (VU resources are pre-allocated, to ensure performance will not be affected when scaling up the load level)
iterations | The aggregate number of times the VUs in the test have executed the JS script (the default function).
data_received | The amount of received data. Read this example to track data for an individual URL.
data_sent | The amount of data sent. Read this example to track data for an individual URL.