// اضافه کردن پشتیبانی لمسی برای منوهای آبشاری
document.addEventListener('DOMContentLoaded', function () {
    var dropdownSubmenus = document.querySelectorAll('.dropdown-submenu');

    dropdownSubmenus.forEach(function (item) {
        // برای دستگاه‌های لمسی
        item.addEventListener('click', function (e) {
            if (window.innerWidth < 992) { // فقط در حالت موبایل
                e.preventDefault();
                e.stopPropagation();
                var submenu = this.querySelector('.dropdown-menu');
                if (submenu.style.display === 'block') {
                    submenu.style.display = 'none';
                } else {
                    submenu.style.display = 'block';
                }
            }
        });
    });

    // بستن منوها با کلیک خارج از آنها
    document.addEventListener('click', function (e) {
        if (window.innerWidth < 992) {
            var openMenus = document.querySelectorAll('.dropdown-submenu .dropdown-menu');
            openMenus.forEach(function (menu) {
                if (menu.style.display === 'block' && !menu.contains(e.target) && !menu.previousElementSibling.contains(e.target)) {
                    menu.style.display = 'none';
                }
            });
        }
    });
});