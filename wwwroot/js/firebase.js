// firebase.js
import { initializeApp } from 'https://www.gstatic.com/firebasejs/10.12.2/firebase-app.js';
import { getDatabase, ref, set } from 'https://www.gstatic.com/firebasejs/10.12.2/firebase-database.js';

const firebaseConfig = {
    databaseURL: "https://qldclb-770f5-default-rtdb.asia-southeast1.firebasedatabase.app/",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

// Khởi tạo Realtime Database
const database = getDatabase(app);

// Định nghĩa hàm writeUserData và gán vào phạm vi global
window.writeUserData = function (userId, message, link) {
    var timestamp = new Date().getTime();
    set(ref(database, 'users/' + timestamp), {
        username: userId,
        email: message,
        profile_picture: link
    })
        .then(() => {
            console.log("Dữ liệu đã được lưu thành công!");
        })
        .catch((error) => {
            console.error("Lỗi khi lưu dữ liệu: ", error);
        });
};
