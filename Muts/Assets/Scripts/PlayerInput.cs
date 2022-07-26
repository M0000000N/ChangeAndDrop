using UnityEngine;
namespace SBPScripts
{
    // �÷��̾� ĳ���͸� �����ϱ� ���� ����� �Է��� ����
    // ������ �Է°��� �ٸ� ������Ʈ���� ����� �� �ֵ��� ����
    public class PlayerInput : MonoBehaviour
    {
        public string MoveAxisName = "Vertical"; // �յ� �������� ���� �Է��� �̸�
        public string RotateAxisName = "Horizontal"; // �¿� ȸ���� ���� �Է��� �̸�
                                                     //public string FireButtonName = "Fire1"; // �߻縦 ���� �Է� ��ư �̸�
        public string ReloadButtonName = "Reload"; // �������� ���� �Է� ��ư �̸�

        // �� �Ҵ��� ���ο����� ����
        public float MoveDirection { get; private set; } // ������ ������ �Է°�
        public float Rotate { get; private set; } // ������ ȸ�� �Է°�
        public bool CanFire { get; private set; } // ������ �߻� �Է°�
        public bool Return { get; private set; } // ������ ������ �Է°�

        // �������� ����� �Է��� ����
        private void Update()
        {
            //// ���ӿ��� ���¿����� ����� �Է��� �������� �ʴ´�
            //if (GameManager.Instance.IsGameover)
            //{
            //    MoveDirection = 0;
            //    Rotate = 0;
            //    CanFire = false;
            //    CanReload = false;
            //    return;
            //}

            // move�� ���� �Է� ����
            MoveDirection = Input.GetAxis(MoveAxisName);
            // rotate�� ���� �Է� ����
            Rotate = Input.GetAxis(RotateAxisName);
            // fire�� ���� �Է� ����
            //CanFire = Input.GetButton(FireButtonName);
            // reload�� ���� �Է� ����
            Return = Input.GetButtonDown(ReloadButtonName);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay()
        }
    }
}