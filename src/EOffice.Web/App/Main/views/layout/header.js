(function () {
    var controllerId = 'app.views.layout.header';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'abp.services.app.user', function ($rootScope, $state, userService) {
            var vm = this;

            vm.languages = abp.localization.languages;
            vm.currentLanguage = abp.localization.currentLanguage;

            vm.menu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;

            $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
                vm.currentMenuName = toState.menu;
            });

            userService.getCurrentUser().success(function (data) {
                vm.currentUser = data;
            });
        }
    ]);
})();