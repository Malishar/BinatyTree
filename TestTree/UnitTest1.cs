using LibraryClass;
using BinatyTree;
namespace TestTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateAverageDate_EmptyTree_ReturnsZero()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(0);

            // Act
            double averageDate = tree.CalculateAverageDate();

            // Assert
            Assert.AreEqual(0, averageDate);
        }

        [TestMethod]
        public void CalculateAverageDate_MultipleNodes_ReturnsCorrectAverage()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(3);
            tree.root.Data.Date = 1000;
            tree.root.Left.Data.Date = 2000;
            tree.root.Right.Data.Date = 3000;

            // Act
            double result = tree.CalculateAverageDate();

            // Assert
            Assert.AreEqual(2000, result);
        }

        [TestMethod]
        public void MakeTree_ReturnsNull_WhenLengthIsZero()
        {
            // Arrange
            int length = 0;
            var binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void MakeTree_ReturnsSingleNode_WhenLengthIsOne()
        {
            // Arrange
            int length = 1;
            var binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Left);
            Assert.IsNull(result.Right);
        }

        [TestMethod]
        public void MakeTree_ReturnsBalancedTree_WhenLengthIsEven()
        {
            // Arrange
            int length = 6; // Even length
            var binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Left);
            Assert.IsNotNull(result.Right);
        }

        [TestMethod]
        public void MakeTree_ReturnsBalancedTree_WhenLengthIsOdd()
        {
            // Arrange
            int length = 7; // Odd length
            var binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Left);
            Assert.IsNotNull(result.Right);
        }

        [TestMethod]
        public void AddPoint_AddsData_WhenTreeIsEmpty()
        {
            // Arrange
            var binaryTree = new MyTree<BankCard>(3); 
            var data = new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 };

            // Act
            binaryTree.AddPoint(data);

            // Assert
            Assert.IsTrue(binaryTree.Contains(data));
        }

        [TestMethod]
        public void AddPoint_DoesNotAddData_WhenDataExistsInTree()
        {
            // Arrange
            var binaryTree = new MyTree<BankCard>(3); 
            var existingData = new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 };
            binaryTree.AddPoint(existingData);

            // Act
            binaryTree.AddPoint(existingData);

            // Assert
            Assert.AreEqual(4, binaryTree.Count);
        }

        [TestMethod]
        public void AddPoint_AddsDataToCorrectLocation()
        {
            // Arrange
            var binaryTree = new MyTree<BankCard>(3);
            var rootData = new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 };
            binaryTree.AddPoint(rootData);
            var leftData = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 20230502 };
            var rightData = new BankCard { Number = "567890123", Owner = "Alice Johnson", Date = 20230503 };

            // Act
            binaryTree.AddPoint(leftData);
            binaryTree.AddPoint(rightData);

            // Assert
            Assert.IsTrue(binaryTree.Contains(leftData));
            Assert.IsTrue(binaryTree.Contains(rightData));
        }

        [TestMethod]
        public void DeleteTree_RemovesAllNodesFromTree()
        {
            // Arrange
            var binaryTree = new MyTree<BankCard>(3);
            binaryTree.AddPoint(new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 });
            binaryTree.AddPoint(new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 20230502 });
            binaryTree.AddPoint(new BankCard { Number = "567890123", Owner = "Alice Johnson", Date = 20230503 });

            // Act
            binaryTree.DeleteTree();

            // Assert
            Assert.AreEqual(0, binaryTree.Count);
            Assert.IsNull(binaryTree.root);
        }

        [TestMethod]
        public void DeleteNode_RemovesAllNodesRecursively()
        {
            // Arrange
            var binaryTree = new MyTree<BankCard>(3);
            binaryTree.AddPoint(new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 });
            binaryTree.AddPoint(new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 20230502 });
            binaryTree.AddPoint(new BankCard { Number = "567890123", Owner = "Alice Johnson", Date = 20230503 });

            // Act
            binaryTree.DeleteNode(binaryTree.root);

            // Assert
            Assert.AreEqual(6, binaryTree.Count);
        }

        public bool AreTreesEqual(MyTree<BankCard> tree1, MyTree<BankCard> tree2)
        {
            return AreSubtreesEqual(tree1.root, tree2.root);
        }

        public bool AreSubtreesEqual(Point<BankCard> node1, Point<BankCard> node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            if (!node1.Data.Equals(node2.Data)) return false;
            return AreSubtreesEqual(node1.Left, node2.Left) && AreSubtreesEqual(node1.Right, node2.Right);
        }

        [TestMethod]
        public void Clone_ShouldReturnExactCopyOfTree()
        {
            // Arrange
            var originalTree = new MyTree<BankCard>(2);
            originalTree.AddPoint(new BankCard { Number = "1234", Owner = "Владимир Мономах", Date = 2024 });
            originalTree.AddPoint(new BankCard { Number = "4567", Owner = "Владимир КрасноСолнышко", Date = 2021 });

            // Act
            var clonedTree = originalTree.Clone();

            // Assert
            Assert.IsNotNull(clonedTree);
            Assert.AreNotSame(originalTree, clonedTree);
            Assert.IsTrue(AreTreesEqual(originalTree, clonedTree));
        }

    }
}
