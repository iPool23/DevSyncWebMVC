document.addEventListener('DOMContentLoaded', function () {
    const sidebar = document.getElementById('sidebar');
    const sidebarToggle = document.getElementById('sidebarToggle');
    const isMobile = window.innerWidth <= 768;

    function toggleSidebar() {
        sidebar.classList.toggle('collapsed');
        document.body.classList.toggle('sidebar-collapsed');
    }

    // En móvil, iniciar con el sidebar colapsado
    if (isMobile) {
        toggleSidebar();
    }

    sidebarToggle.addEventListener('click', toggleSidebar);

    // Cerrar sidebar al hacer clic fuera en móvil
    document.addEventListener('click', function (e) {
        if (isMobile && !sidebar.contains(e.target) && !sidebar.classList.contains('collapsed')) {
            toggleSidebar();
        }
    });

    // Ajustar al cambiar el tamaño de la ventana
    window.addEventListener('resize', function () {
        const isMobile = window.innerWidth <= 768;
        if (isMobile && !sidebar.classList.contains('collapsed')) {
            toggleSidebar();
        }
    });
});