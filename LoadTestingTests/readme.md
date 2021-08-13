
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




running (28.6s), 0000/1000 VUs, 1366 complete and 0 interrupted iterations
default ✓ [======================================] 1000 VUs  15s

     data_received..................: 5.3 MB 184 kB/s
     data_sent......................: 509 kB 18 kB/s
     http_req_blocked...............: avg=2.07s    min=0s       med=2.57s    max=8.24s   p(90)=4.02s    p(95)=4.53s
     http_req_connecting............: avg=223.99ms min=0s       med=243.05ms max=780.3ms p(90)=426.36ms p(95)=660.19ms
     http_req_duration..............: avg=13.73s   min=230.2ms  med=14s      max=22.46s  p(90)=18.49s   p(95)=19.91s
       { expected_response:true }...: avg=13.73s   min=230.2ms  med=14s      max=22.46s  p(90)=18.49s   p(95)=19.91s
     http_req_failed................: 0.00%  ✓ 0         ✗ 1366
     http_req_receiving.............: avg=105.15µs min=0s       med=0s       max=1.13ms  p(90)=506.85µs p(95)=793.7µs
     http_req_sending...............: avg=151.64µs min=0s       med=0s       max=6.24ms  p(90)=519.44µs p(95)=800.02µs
     http_req_tls_handshaking.......: avg=1.81s    min=0s       med=2.22s    max=7.93s   p(90)=3.6s     p(95)=4.2s
     http_req_waiting...............: avg=13.73s   min=229.79ms med=14s      max=22.46s  p(90)=18.49s   p(95)=19.91s
     http_reqs......................: 1366   47.816048/s
     iteration_duration.............: avg=15.81s   min=1.45s    med=15.61s   max=25.61s  p(90)=22.09s   p(95)=24.31s
     iterations.....................: 1366   47.816048/s
     vus............................: 1      min=1       max=1000
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