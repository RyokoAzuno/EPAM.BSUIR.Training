var app = angular.module('myApp', ['ngRoute']);

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {

    $routeProvider.when('/', {          //Routing for showing list of books
        templateUrl: '/App/Views/BookList.html',
        controller: 'bookController'
    }).when('/BookList', {                       //Routing for list of books
        templateUrl: '/App/Views/BookList.html',
        controller: 'bookController'
    })
        .when('/AddBook', {                       //Routing for add book
        templateUrl: '/App/Views/AddBook.html',
        controller: 'bookController'
    })
        .when('/EditBook/:bookId', {             //Routing for geting single book details
            templateUrl: '/App/Views/EditBook.html',
            controller: 'bookController'
    })
        .when('/DeleteBook/:bookId', {           //Routing for delete book
            templateUrl: '/App/Views/DeleteBook.html',
            controller: 'bookController'
    })
        .otherwise({                                //Default Routing
            controller: 'bookController'
        })
}]);