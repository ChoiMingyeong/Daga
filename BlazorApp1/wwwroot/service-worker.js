// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
self.addEventListener('install', event => {
    // 초기 캐시 저장
});

self.addEventListener('activate', event => {
    // 이전 캐시 정리
});

self.addEventListener('fetch', event => {
    // 네트워크 요청 가로채서 캐시 반환
});