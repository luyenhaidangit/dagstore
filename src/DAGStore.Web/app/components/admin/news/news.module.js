// Register module
var news = angular.module('DAGStore.news', ['DAGStore.common']);

// Config module
news.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'news',
            url: '/news',
            templateUrl: '/app/components/admin/news/newsListView.html',
            controller: "newsListController",
            parent: 'base',
        },
        {
            name: 'add-news',
            url: '/news/add',
            templateUrl: '/app/components/admin/news/newsAddView.html',
            controller: "newsAddController",
            parent: 'base',
        },
        //{
        //    name: 'info-news',
        //    url: '/news/info/:id',
        //    templateUrl: '/app/components/admin/news/newsInfoView.html',
        //    controller: "newsInfoController",
        //    parent: 'base',
        //},
        //{
        //    name: 'edit-news',
        //    url: '/news/edit/:id',
        //    templateUrl: '/app/components/admin/news/newsEditView.html',
        //    controller: "newsEditController",
        //    parent: 'base',
        //}
        ];
    states.forEach((state) => $stateProvider.state(state));
});




