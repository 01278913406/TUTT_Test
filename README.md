Hướng dẫn chạy project.
chạy API đầu tiên xong chạy Client.


I. chạy Project API trên .net core 8 (địa chỉ endpoint: https://localhost:7160)
- mở project bằng file TUTT_API.sln trong thư mục root
- cấu hình kết nối DB mongodb trong file appsettings.json
- chạy project với cấu hình https
- khi chạy xong thì có thể test dịch vụ theo link https://localhost:7160/swagger/index.html
- test API Leagues lấy danh sách các giải đấu trên thế giới: truyền offset =1 và limit = 100

II. chạy Client (môi trường chạy node ^20.12.1, angular ^17.3.0)
- Client là trong thư mục Tutt_Client trong thư mục root (~\TUTT_Test\Tutt_Client)
- cài đặt cái gọi phụ thuộc: npm i
  cd ~\TUTT_Test\Tutt_Client
  npm i
- cấu hình địa chỉ endpoint API trong file: src/environment/environment.ts
  apiDomain: {
        EndPoint: 'https://localhost:7160',
    },
  nếu thay đổi port của API thì cần thay đổi địa chỉ endpoint này nếu không thay đổi thì không cần cấu hình
- chạy client
   cd ~\TUTT_Test\Tutt_Client
   npm run start
- địa chỉ web client: http://localhost:4200/
