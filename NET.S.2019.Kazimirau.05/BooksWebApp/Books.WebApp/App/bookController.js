app.controller('bookController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
    $scope.ListOfBooks;
    $scope.Status;

    $scope.Close = function () {
        $location.path('/BookList');
    }

    //Get all books
    $http.get("api/book/GetAllBooks").success(function (data) {
        $scope.ListOfBooks = data;
    })
        .error(function (data) {
            $scope.Status = "data not found!";
        });

    //Add new book
    $scope.Add = function () {
        var bookData = {
            ISBN: $scope.ISBN,
            Author: $scope.Author,
            Name: $scope.Name,
            Publisher: $scope.Publisher,
            Year: $scope.Year,
            NumberOfPages: $scope.NumberOfPages,
            Price: $scope.Price
        };
        //debugger;
        $http.post("api/book/AddBook", bookData).success(function (data) {
            $location.path('/BookList');
        }).error(function (data) {
            console.log(data);
            $scope.error = "Something wrong when adding new book " + data.ExceptionMessage;
        });
    }

    //Fill the book records for update
    if ($routeParams.bookId) {
        $scope.Id = $routeParams.bookId;

        $http.get('api/book/GetBook/' + $scope.Id).success(function (data) {
                $scope.ISBN = data.ISBN,
                $scope.Author = data.Author,
                $scope.Name = data.Name,
                $scope.Publisher = data.Publisher,
                $scope.Year = data.Year,
                $scope.NumberOfPages = data.NumberOfPages,
                $scope.Price = data.Price
        });
    }

    //Update the book records
    $scope.Update = function () {
        //debugger;
        var bookData = {
            ISBN: $scope.ISBN,
            Author: $scope.Author,
            Name: $scope.Name,
            Publisher: $scope.Publisher,
            Year: $scope.Year,
            NumberOfPages: $scope.NumberOfPages,
            Price: $scope.Price
        };
            $http.put("api/book/UpdateBook", bookData).success(function (data) {
                $location.path('/BookList');
            }).error(function (data) {
                console.log(data);
                $scope.error = "Something wrong when adding updating book " + data.ExceptionMessage;
            });
    }


    //Delete the selected book from the list
    $scope.Delete = function () {
            $http.delete("api/book/DeleteBook/" + $scope.Id).success(function (data) {
                $location.path('/BookList');
            }).error(function (data) {
                console.log(data);
                $scope.error = "Something wrong when adding Deleting book " + data.ExceptionMessage;
            });
    }
}]);

//    $scope.add = function () {
//        if ($scope.form.$valid) {
//            $scope.Book = {};
//            $scope.Book.ISBN = $scope.Book_ISBN;
//            $scope.Book.Author = $scope.Book_Author;
//            $scope.Book.Name = $scope.Book_Name;
//            $scope.Book.Publisher = $scope.Book_Publisher;
//            $scope.Book.Year = $scope.Book_Year;
//            $scope.Book.NumberOfPages = $scope.Book_NumberOfPages;
//            $scope.Book.Price = $scope.Book_Price;

//            $http({
//                method: 'POST',
//                url: '/api/values/',
//                data: this.Book
//            }).then(function (response) {
//                alert(response.data);
//                $scope.getAll();
//            })
//        }
//    };

//    $scope.getAll = function () {
//        $http({ method: 'GET', url: '/api/values/' }).then(function (response) {
//            $scope.Books = response.data;
//        }, function () {
//            alert("Error!!");
//        })
//    };
//})
